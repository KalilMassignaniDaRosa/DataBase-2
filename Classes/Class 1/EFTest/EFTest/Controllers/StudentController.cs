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

namespace EFTest.Controllers
{
    public class StudentController : Controller
    {
        // Permite salvar logs
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentCourseRepository _scRepository;
        private readonly SchoolContext _context;

        public StudentController(
            ILogger<StudentController> logger,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository,
            IStudentCourseRepository studentCoursesRepository,
            SchoolContext context
        )
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _scRepository = studentCoursesRepository;
            _context = context;
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

            // Garante que SelectedCourseIds
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

            // Inclui cursos e materias
            await _context.Entry(student)
                          .Collection(s => s.StudentCourses!)
                          .Query()
                          .Include(sc => sc.Course)
                          .LoadAsync();

            await _context.Entry(student)
                          .Collection(s => s.StudentModules!)
                          .Query()
                          .Include(sm => sm.Module)
                          .ThenInclude(m => m!.CourseModules)
                          .LoadAsync();

            // Curso selecionado
            int selectedCourseId = SelectedCourseId ?? student.StudentCourses!.FirstOrDefault()?.CourseID ?? 0;
            ViewBag.SelectedCourseId = selectedCourseId;

            // Dropdown
            ViewBag.StudentCourses = student.StudentCourses!
                .Select(sc => new SelectListItem
                {
                    Text = sc.Course!.Name,
                    Value = sc.CourseID.ToString(),
                    Selected = (sc.CourseID == selectedCourseId)
                })
                .ToList();

            return View(student);
        }
        #endregion

        #region Others
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
