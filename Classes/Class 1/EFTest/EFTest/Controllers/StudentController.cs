using EFTest.Data;
using EFTest.Models;
using EFTest.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EFTest.Controllers
{
    public class StudentController : Controller
    {
        // Permite salvar logs
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;

        public StudentController(
            ILogger<StudentController> logger,
            IStudentRepository studentRepository,
            ICourseRepository courseRepository
        )
        {
            _logger = logger;
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            var students = await _studentRepository.GetAllWithCourses();

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

                // Associa os cursos selecionados
                foreach (var courseId in SelectedCourseIds)
                {
                    await _studentRepository.AddCourseToStudent(student.ID, courseId);
                }

                return RedirectToAction("Index");
            }

            // Recarrega os cursos se houver erro
            ViewBag.Courses = await _courseRepository.GetAll();
            return View(student);
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var student = await _studentRepository.GetByIdWithCourses(id);
            if (student == null)
                return NotFound();

            ViewBag.Courses = await _courseRepository.GetAll();

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Student student, int[] SelectedCourseIds)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Courses = await _courseRepository.GetAll();
                return View(student);
            }

            // Atualiza dados
            await _studentRepository.Update(student);

            // Obtem cursos atuais do estudante
            var studentWithCourses = await _studentRepository.GetByIdWithCourses(student.ID);
            var currentCourseIds = studentWithCourses.StudentCourses!.Select(sc => sc.CourseID).ToList();

            // Remove cursos desmarcados
            foreach (var courseId in currentCourseIds.Except(SelectedCourseIds))
            {
                await _studentRepository.RemoveCourseFromStudent(student.ID, courseId);
            }

            // Adiciona novos cursos selecionados
            foreach (var courseId in SelectedCourseIds.Except(currentCourseIds))
            {
                await _studentRepository.AddCourseToStudent(student.ID, courseId);
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

        #region Others
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
