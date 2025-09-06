using EFTest.Models;
using EFTest.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EFTest.Controllers
{
    public class CourseController : Controller
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseRepository _courseRepository;

        public CourseController(
            ILogger<CourseController> logger, 
            ICourseRepository courseRepository
        )
        {
            _logger = logger;
            _courseRepository = courseRepository;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            var courses = await _courseRepository.GetAllWithStudents();
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
        public async Task<IActionResult> Update(int id)
        {
            var course = await _courseRepository.GetById(id)!;
            if (course == null) 
                return NotFound();

            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Course course)
        {
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
