using EFTest.Data;
using EFTest.Models;
using EFTest.Models.Students;
using EFTest.Repository.CoursesRepository;
using EFTest.Repository.StudentsRepository;
using EFTest.Repository.StudentsCoursesRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
using EFTest.Models.Modules;
using EFTest.Repository.ModulesRepository;
using EFTest.ViewModel;
using EFTest.Repository.StudentsModulesRepository;

namespace EFTest.Controllers
{
    public class StudentController : Controller
    {
        // Permite salvar logs
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IModuleRepository _moduleRepository;
        private readonly IStudentCourseRepository _scRepository;
        private readonly IStudentModuleRepository _smRepository;

        // DTO = Data Transfer Object
        // Usado para passar dados,parecido com viewmodel
        // Record armazena dados imutaveis
        private record PrerequisiteDto(int Id, string Name);
        private record ModuleOptionDto(int ID, string Name, 
            DayOfWeek? DayOfWeek, List<PrerequisiteDto> Prerequisites);
        private record UnavailableModuleDto(int ID, string Name, 
            DayOfWeek? DayOfWeek, List<string> Reasons);

        public StudentController(
            ILogger<StudentController> logger,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IModuleRepository moduleRepository,
            IStudentCourseRepository studentCoursesRepository,
            IStudentModuleRepository studentModuleRepository
        )
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _moduleRepository = moduleRepository;
            _scRepository = studentCoursesRepository;
            _smRepository = studentModuleRepository;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAll();

            // Pega cursos do estudante
            foreach (var s in students)
            {
                s.StudentCourses = await _scRepository.GetByStudentId(s.ID);
            }

            return View(students);
        }
        #endregion

        #region Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var courses = await _courseRepository.GetAll();
            // Passando por ViewBag
            ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student, int[] SelectedCourseIds)
        {
            if (ModelState.IsValid)
            {
                await _studentRepository.Create(student);

                foreach (var courseId in SelectedCourseIds)
                {
                    await _scRepository.AddCourseToStudent(student.ID, courseId);
                }

                return RedirectToAction("Index");
            }

            // Recarrega cursos se houver erro
            var courses = await _courseRepository.GetAll();
            ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();

            return View(student);
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            // Caso o id seja null
            if (!id.HasValue)
                return BadRequest(); // Cod 400

            var student = await _studentRepository.GetById(id.Value);
            if (student == null)
                return NotFound(); // Cod 404

            // Carrega so os ativos
            student.StudentCourses = await _scRepository.GetByStudentId(student.ID);

            var courses = await _courseRepository.GetAll();
            ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? routeId, Student student, int[]? SelectedCourseIds)
        {
            if (!routeId.HasValue)
                return BadRequest();

            if (routeId.Value != student.ID)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                var courses = await _courseRepository.GetAll();
                ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();

                return View(student);
            }

            await _studentRepository.Update(student);

            // Se for null cria lista vazia
            SelectedCourseIds ??= Array.Empty<int>();

            // Obtem cursos atuais
            var currentStudentCourses = await _scRepository.GetByStudentId(student.ID);
            var currentCourseIds = currentStudentCourses
                                    .Where(sc => sc.CancelDate == null)
                                    .Select(sc => sc.CourseID)
                                    .ToList();

            // Remove cursos desmarcados
            foreach (var courseId in currentCourseIds.Except(SelectedCourseIds))
            {
                await _scRepository.RemoveCourseFromStudent(student.ID, courseId);
            }

            // Adiciona novos cursos selecionados
            foreach (var courseId in SelectedCourseIds.Except(currentCourseIds))
            {
                await _scRepository.AddCourseToStudent(student.ID, courseId);
            }

            return RedirectToAction("Index");
        }
        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepository.GetById(id)!;
            if (student == null)
                return NotFound();
            
            await _studentRepository.Delete(student);

            return RedirectToAction("Index");
        }
        #endregion

        #region Profile
        [HttpGet]
        public async Task<IActionResult> Profile(int id, int? SelectedCourseId)
        {
            var student = await _studentRepository.GetById(id);
            if (student == null)
                return NotFound();

            // Carrega cursos e materias do aluno
            student.StudentCourses = await _scRepository.GetByStudentId(student.ID);
            student.StudentModules = await _smRepository.GetByStudentId(student.ID);

            ViewBag.SelectedCourseId = SelectedCourseId;

            ViewBag.StudentCourses = student.StudentCourses!
                .Select(sc => new SelectListItem
                {
                    Text = sc.Course!.Name,
                    Value = sc.CourseID.ToString(),
                    Selected = false
                })
                .ToList();

            if (SelectedCourseId.HasValue)
            {
                var selectedCourse = await _courseRepository.GetById(
                    SelectedCourseId.Value, includeModules: true);

                if (selectedCourse != null)
                {
                    var courseModules = selectedCourse.CourseModules!
                        .Select(cm =>
                        {
                            var module = cm.Module!;
                            var studentModule = student.StudentModules?
                                .FirstOrDefault(sm => sm.ModuleID == cm.ModuleID);

                            return new
                            {
                                Semester = cm.Semester,
                                ModuleId = module.ID,
                                Name = module.Name,
                                WorkloadHours = module.WorkloadHours,
                                DayOfWeek = cm.DayOfWeek,
                                Frequency = studentModule?.Frequency,
                                Grade = studentModule?.Grade,
                                Period = studentModule?.SignDate,
                                Status = studentModule?.Status.ToString() 
                                ?? ModuleStatusEnum.NotTaken.ToString()
                            };
                        })
                        .OrderBy(x => x.Semester)
                        .ThenBy(x => x.Name)
                        .ToList();

                    ViewBag.CourseModules = courseModules;
                }
                else
                {
                    ViewBag.CourseModules = new List<object>();
                }
            }
            else
            {
                ViewBag.CourseModules = new List<object>();
            }

            return View(student);
        }
        #endregion

        #region Modules
        [HttpGet]
        public async Task<IActionResult> AddModuleToStudent(int studentId, int? courseId)
        {
            var student = await _studentRepository.GetById(studentId);
            if (student == null)
                return NotFound();

            student.StudentCourses = await _scRepository.GetByStudentId(student.ID);
            student.StudentModules = await _smRepository.GetByStudentId(student.ID);

            if (!courseId.HasValue)
            {
                var emptyVm = new StudentModuleCourseViewModel
                {
                    Student = student,
                    Course = null!,
                    AllModules = new List<Module>()
                };
                ViewBag.SelectedCourseId = 0;

                return View("AddModule", emptyVm);
            }

            var selectedCourse = await _courseRepository.
                GetByIdWithModulesAndPrerequisites(courseId.Value);
            if (selectedCourse == null)
                return NotFound();

            var viewModel = new StudentModuleCourseViewModel
            {
                Student = student,
                Course = selectedCourse,
                AllModules = selectedCourse.CourseModules!.Select(cm => cm.Module!).ToList()
            };

            ViewBag.SelectedCourseId = courseId.Value;

            return View("AddModule", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddModuleToStudent(int studentId, int courseId, int moduleId)
        {
            var student = await _studentRepository.GetById(studentId);
            if (student == null)
                return NotFound();

            // Usa repository em vez de _context
            var courseModule = await _smRepository.GetCourseModule(courseId, moduleId);

            if (courseModule == null)
            {
                ModelState.AddModelError("", "Selected module not found in that course");
                return await AddModuleToStudent(studentId, courseId);
            }

            // Verifica existencia
            var existingModule = await _smRepository.GetByIds(studentId, moduleId, courseId);

            if (existingModule != null)
            {
                if (existingModule.CancelDate != null)
                {
                    // Reativa
                    existingModule.CancelDate = null;
                    existingModule.Status = ModuleStatusEnum.Enrolled;
                    existingModule.SignDate = DateTime.Now;
                    existingModule.DayOfWeek = courseModule.DayOfWeek;

                    await _smRepository.Update(existingModule);

                    return RedirectToAction("Profile", new
                    {
                        id = studentId,
                        SelectedCourseId = courseId
                    });
                }
                else
                {
                    ModelState.AddModelError("", "Student already has this module in that course");
                    return await AddModuleToStudent(studentId, courseId);
                }
            }

            await _smRepository.AddModuleToStudent(studentId, moduleId,
                courseId, courseModule.DayOfWeek);

            return RedirectToAction("Profile", new { id = studentId, SelectedCourseId = courseId });
        }

        [HttpPost]
        public async Task<IActionResult> CancelModule(int studentId, int moduleId, int? selectedCourseId)
        {
            await _smRepository.RemoveModuleFromStudent(studentId, moduleId);

            if (selectedCourseId.HasValue)
                return RedirectToAction("Profile", new { id = studentId, 
                    SelectedCourseId = selectedCourseId.Value });

            return RedirectToAction("Profile", new { id = studentId });
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
