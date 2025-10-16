using EFTest.Models;
using EFTest.Models.Modules;
using EFTest.Models.Courses;
using EFTest.Repository.CoursesRepository;
using EFTest.Repository.ModulesRepository;
using EFTest.Repository.CoursesModulesRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EFTest.Models.Students;

namespace EFTest.Controllers
{
    public class ModuleController : Controller
    {
        private readonly ILogger<ModuleController> _logger;
        private readonly IModuleRepository _moduleRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly ICourseModuleRepository _cmRepository;

        public ModuleController(
            ILogger<ModuleController> logger,
            IModuleRepository moduleRepository,
            ICourseRepository courseRepository,
            ICourseModuleRepository courseModuleRepository
        )
        {
            _logger = logger;
            _moduleRepository = moduleRepository;
            _courseRepository = courseRepository;
            _cmRepository = courseModuleRepository;
        }

        #region Index
        public async Task<IActionResult> Index()
        {
            var modules = await _moduleRepository.GetAll();

            foreach (var module in modules)
            {
                // Carrega os CourseModules
                var courseModules = await _cmRepository.GetByModuleId(module.ID);
                module.CourseModules = courseModules?.ToList();

                // Carrega os StudentModules
                var studentModules = await _moduleRepository.GetStudentModulesByModuleId(module.ID);
                module.StudentModules = studentModules?.ToList();
            }

            return View(modules);
        }
        #endregion

        #region Create
                [HttpGet]
        public async Task<IActionResult> Create()
        {
            var courses = await _courseRepository.GetAll();
            ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Module module, 
            int[] SelectedCourseIds, int[] Semesters, DayOfWeek[] DaysOfWeek)
        {
            if (ModelState.IsValid)
            {
                await _moduleRepository.Create(module);

                // Associa cursos selecionados
                for (int i = 0; i < SelectedCourseIds.Length; i++)
                {
                    await _cmRepository.AddModuleToCourse(
                        module.ID, SelectedCourseIds[i], Semesters[i], DaysOfWeek[i]
                    );
                }

                return RedirectToAction("Index");
            }

            var courses = await _courseRepository.GetAll();
            ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();
           
            return View(module);
        }
        #endregion

        #region Update
        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var module = await _moduleRepository.GetById(id.Value);
            if (module == null)
                return NotFound();

            var courses = await _courseRepository.GetAll();
            ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();

            var courseModules = await _cmRepository.GetByModuleId(module.ID);
            module.CourseModules = courseModules;

            return View(module);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? routeId, Module module,
            int[] SelectedCourseIds, int[] Semesters, DayOfWeek[] DaysOfWeek)
        {
            if (!routeId.HasValue)
                return BadRequest();

            if (routeId.Value != module.ID)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _moduleRepository.Update(module);

                // Pega todas as associacoes da materia
                var existingCourseModules = await _cmRepository.GetByModuleId(module.ID);

                // Remove se nao for selecionado
                foreach (var cm in existingCourseModules)
                {
                    if (!SelectedCourseIds.Contains(cm.CourseID))
                    {
                        await _cmRepository.RemoveModuleFromCourse(cm.CourseID, module.ID);
                    }
                }

                // Adiciona selecionadas
                for (int i = 0; i < SelectedCourseIds.Length; i++)
                {
                    await _cmRepository.AddModuleToCourse(
                        module.ID, SelectedCourseIds[i], Semesters[i], DaysOfWeek[i]
                    );
                }

                return RedirectToAction("Index");
            }

            // Se der erro carrega os cursos
            var courses = await _courseRepository.GetAll();
            ViewBag.Courses = courses.OrderBy(c => c.Name).ToList();

            return View(module);
        }

        #endregion

        #region Delete
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var module = await _moduleRepository.GetById(id);
            if (module == null)
                return NotFound();

            await _moduleRepository.Delete(module);
            
            return RedirectToAction("Index");
        }
        #endregion

        #region Error
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var errorModel = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
            return View(errorModel);
        }
        #endregion
    }
}