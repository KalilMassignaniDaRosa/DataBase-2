using EFTest.Data;
using EFTest.Models.Courses;
using EFTest.Models.Modules;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.CoursesModulesRepository
{
    public class CourseModuleRepository : ICourseModuleRepository
    {
        private readonly SchoolContext _context;

        public CourseModuleRepository(SchoolContext context) => _context = context;

        #region Basic Operations
        public async Task Create(CourseModule courseModule)
        {
            await _context!.CourseModules.AddAsync(courseModule);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(CourseModule courseModule)
        {
            _context!.CourseModules.Remove(courseModule);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Queries
        public async Task<CourseModule?> GetByIds(int courseId, int moduleId)
        {
            var courseModule = await _context.CourseModules
                .Include(cm => cm.Course)
                .Include(cm => cm.Module)
                .FirstOrDefaultAsync(cm => cm.CourseID == courseId && cm.ModuleID == moduleId);

            return courseModule;
        }

        public async Task<List<CourseModule>> GetAll()
        {
            var courseModules = await _context.CourseModules
                .Include(cm => cm.Course)
                .Include(cm => cm.Module)
                .ToListAsync();

            return courseModules;
        }

        public async Task<List<CourseModule>> GetByCourseId(int courseId)
        {
            var courseModules = await _context.CourseModules
                .Include(cm => cm.Course)
                .Include(cm => cm.Module)
                .Where(cm => cm.CourseID == courseId)
                .ToListAsync();

            return courseModules;
        }

        public async Task<List<CourseModule>> GetByModuleId(int moduleId)
        {
            var courseModules = await _context.CourseModules
                .Include(cm => cm.Course)
                .Include(cm => cm.Module)
                .Where(cm => cm.ModuleID == moduleId)
                .ToListAsync();

            return courseModules;
        }

        public async Task<Course?> GetCourseByIdWithModules(int courseId)
        {
            var course = await _context.Courses
                .Include(c => c.CourseModules!)
                .ThenInclude(cm => cm.Module)
                .FirstOrDefaultAsync(c => c.ID == courseId);

            return course;
        }

        public async Task<Module?> GetModuleByIdWithCourses(int moduleId)
        {
            var module = await _context.Modules
                .Include(m => m.CourseModules!)
                .ThenInclude(cm => cm.Course)
                .FirstOrDefaultAsync(m => m.ID == moduleId);

            return module;
        }
        #endregion

        #region Enrollments (Add/Update)
        public async Task AddModuleToCourse(int moduleId, int courseId, 
            int semester, DayOfWeek? dayOfWeek = null)
        {
            var exists = await _context.CourseModules
                .FirstOrDefaultAsync(cm => cm.ModuleID == moduleId && cm.CourseID == courseId);

            if (exists != null)
            {
                exists.Semester = semester;
                exists.DayOfWeek = dayOfWeek;
                _context.CourseModules.Update(exists);
                await _context.SaveChangesAsync();
            }
            else
            {
                var cm = new CourseModule
                {
                    ModuleID = moduleId,
                    CourseID = courseId,
                    Semester = semester,
                    DayOfWeek = dayOfWeek
                };
                await _context.CourseModules.AddAsync(cm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCourses(int moduleId, int[] courseIds, 
            int[] semesters, DayOfWeek[] daysOfWeek)
        {
            var current = await GetByModuleId(moduleId);

            foreach (var cm in current)
            {
                if (!courseIds.Contains(cm.CourseID))
                {
                    _context.CourseModules.Remove(cm);
                }
            }

            for (int i = 0; i < courseIds.Length; i++)
            {
                await AddModuleToCourse(moduleId, courseIds[i], semesters[i], daysOfWeek[i]);
            }

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
