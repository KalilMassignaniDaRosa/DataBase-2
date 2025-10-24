    using EFTest.Models;
    using EFTest.Models.Courses;
    using EFTest.Models.Modules;
    using EFTest.Models.Students;
    using EFTest.Repository.CoursesModulesRepository;
    using EFTest.Repository.CoursesRepository;
    using EFTest.Repository.ModulesRepository;
    using EFTest.Repository.StudentsCoursesRepository;
    using EFTest.Repository.StudentsRepository;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    namespace EFTest.Controllers
    {
        public class CourseController : Controller
        {
            private readonly ILogger<CourseController> _logger;
            private readonly ICourseRepository _courseRepository;
            private readonly IModuleRepository _moduleRepository;
            private readonly ICourseModuleRepository _cmRepository;

            public CourseController(
                ILogger<CourseController> logger, 
                ICourseRepository courseRepository,
                IModuleRepository moduleRepository,
                ICourseModuleRepository courseModuleRepository
            
            )
            {
                _logger = logger;
                _courseRepository = courseRepository;
                _moduleRepository = moduleRepository;
                _cmRepository = courseModuleRepository;
            }

            #region Index
            public async Task<IActionResult> Index()
            {
                var courses = await _courseRepository.GetAll(includeModules: true, includeStudents: true);
            
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

            #region Overview
            public async Task<IActionResult> Overview(int id)
            {
                var course = await _courseRepository.GetByIdWithModulesAndPrerequisites(id);

                if (course == null)
                    return NotFound();

                return View(course);
            }
            #endregion

            #region Modules
            [HttpGet]
            public async Task<IActionResult> AddModuleToCourse(int courseId, int semester = 1)
            {
                var course = await _courseRepository.GetById(courseId, includeModules: true);
                if (course == null)
                    return NotFound();

                // Pega todas as materias
                var allModules = await _moduleRepository.GetAll();
                var availableModules = allModules
                    .Where(m => !course.CourseModules!.Any(cm => cm.ModuleID == m.ID))
                    .ToList();

                ViewBag.Modules = availableModules;

                ViewBag.OccupiedDays = await _cmRepository
                    .GetUsedDaysByCourseAndSemester(courseId, semester);
                ViewBag.Semester = semester;

                ViewBag.ExistingModules = course.CourseModules!
                                              .Select(cm => cm.Module!)
                                              .Where(m => m != null)
                                              .ToList();

                return View("AddModule", course);
            }

            [HttpPost]
            public async Task<IActionResult> AddModuleToCourse(int courseId,
                int selectedModuleId, int semester, DayOfWeek? dayOfWeek, int? prerequisiteModuleId)
            {
                var course = await _courseRepository.GetById(courseId, includeModules: true);

                // Verifica dia
                if (dayOfWeek.HasValue)
                {
                    var usedDays = await _cmRepository.GetUsedDaysByCourseAndSemester(courseId, semester);

                    if (usedDays.Contains(dayOfWeek.Value))
                    {
                        ModelState.AddModelError("DayOfWeek", $"Day {dayOfWeek.Value} " +
                            $"is already used in semester {semester}");
                    }
                }

                // Verifica prerequisito
                if (prerequisiteModuleId.HasValue)
                {
                    var isInCourse = course?.CourseModules?.Any(cm => 
                    cm.ModuleID == prerequisiteModuleId.Value) ?? false;

                    if (!isInCourse)
                    {
                        ModelState.AddModelError("Prerequisite", "Selected prerequisite must be a module already in this course");
                    }
                }

                // Se der erro retorna view com dados
                if (!ModelState.IsValid)
                {
                    ViewBag.Modules = await _moduleRepository.GetAll();
                    ViewBag.OccupiedDays = await _cmRepository.GetUsedDaysByCourseAndSemester(courseId, semester);
                    ViewBag.Semester = semester;
                    ViewBag.ExistingModules = course.CourseModules.Select(cm => cm.Module!).ToList();

                    return View("AddModule", course);
                }

                await _cmRepository.AddModuleToCourse(selectedModuleId, courseId, semester, dayOfWeek);

                // Adiciona prerequisito se tiver
                if (prerequisiteModuleId.HasValue)
                    await _moduleRepository.AddPrerequisite(selectedModuleId, prerequisiteModuleId.Value);

                return RedirectToAction("Overview", new { id = courseId });
            }

            [HttpGet]
            public async Task<IActionResult> EditModule(int courseId, int moduleId)
            {
                var cm = await _cmRepository.GetByIds(courseId, moduleId);
                if (cm == null) 
                    return NotFound();

                cm.Module = await _moduleRepository.GetById(cm.ModuleID, includePrerequisites: true);

                ViewBag.OccupiedDays = await _cmRepository
                    .GetUsedDaysByCourseAndSemester(courseId, cm.Semester);
           
                ViewBag.ExistingModules = (await _cmRepository.GetAll())
                                            .Where(x => x.CourseID == courseId)
                                            .Select(x => x.Module!)
                                            .ToList();

                return View(cm);
            }

            [HttpPost]
            public async Task<IActionResult> EditModule(int courseId, int moduleId,
                int semester, DayOfWeek? dayOfWeek, int? prerequisiteModuleId) 
            {
                await _cmRepository.UpdateModuleInCourse(courseId, moduleId, semester, dayOfWeek);

                if (prerequisiteModuleId.HasValue)
                {
                    // Remove os prerequisitos atuais
                    await _moduleRepository.RemoveAllPrerequisites(moduleId);

                    // Depois adiciona o novo
                    await _moduleRepository.AddPrerequisite(moduleId, prerequisiteModuleId.Value);
                }
                else
                {
                    // Se selecionou None remove todos
                    await _moduleRepository.RemoveAllPrerequisites(moduleId);
                }

                return RedirectToAction("Overview", new { id = courseId });
            }


            [HttpPost]
            public async Task<IActionResult> RemoveModuleFromCourse(int courseId, int moduleId)
            {
                var course = await _courseRepository.GetById(courseId, includeModules: true);
                if (course == null)
                    return NotFound();

                var courseModule = course.CourseModules!.FirstOrDefault(cm => cm.ModuleID == moduleId);
                if (courseModule == null)
                    return NotFound();

                await _cmRepository.RemoveModuleFromCourse(courseId, moduleId);

                return RedirectToAction("Overview", new { id = courseId });
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
