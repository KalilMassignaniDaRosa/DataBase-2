using EFTest.Models;
using EFTest.Models.Courses;
using EFTest.Repository.CoursesRepository;
using EFTest.Repository.StudentsCoursesRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseRepository _courseRepository;
        private readonly IStudentCourseRepository _scRepository;

        public CourseController(
            ILogger<CourseController> logger, 
            ICourseRepository courseRepository,
            IStudentCourseRepository studentCoursesRepository
        )
        {
            _logger = logger;
            _courseRepository = courseRepository;
            _scRepository = studentCoursesRepository; 
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepository.GetAll();
            foreach (var course in courses)
            {
                course.StudentCourses = await _scRepository.GetByCourseId(course.ID);
            }

            return View(courses);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            if (ModelState.IsValid)
            {
                await _courseRepository.Create(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var course = await _courseRepository.GetById((int)id!)!;
            if (course == null) 
                return NotFound();

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? routeId, Course course)
        {
            if (!routeId.HasValue)
                return BadRequest();

            if (routeId.Value != course.ID)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _courseRepository.Update(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }
        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _courseRepository.GetById(id)!;
            if (course == null) 
                return NotFound();

            await _courseRepository.Delete(course);
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
