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

        public async Task<List<CourseModule>> GetByCourseId(int courseId, 
            DayOfWeek? dayOfWeek = null, int? semester = null)
        {
            var query = _context.CourseModules
                .Include(cm => cm.Course)
                .Include(cm => cm.Module)
                .Where(cm => cm.CourseID == courseId);

            if (semester.HasValue)
                query = query.Where(cm => cm.Semester == semester.Value);

            if (dayOfWeek.HasValue)
                query = query.Where(cm => cm.DayOfWeek == dayOfWeek.Value);

            var courseModules = await query.ToListAsync();

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

        public async Task<List<CourseModule>> GetModulesByCourseIdAndDay(int courseId, 
            int semester, DayOfWeek? dayOfWeek = null)
        {
            var query = _context.CourseModules
                .Include(cm => cm.Module)
                .Include(cm => cm.Course)
                .Where(cm => cm.CourseID == courseId && cm.Semester == semester);

            if (dayOfWeek.HasValue)
                query = query.Where(cm => cm.DayOfWeek == dayOfWeek.Value);

            var modules = await query.ToListAsync();

            return modules;
        }

        public async Task<List<DayOfWeek>> GetUsedDaysByCourseAndSemester(int courseId, int semester)
        {
            var usedDays = await _context.CourseModules
                .Where(cm => cm.CourseID == courseId &&
                            cm.Semester == semester &&
                            cm.DayOfWeek.HasValue)
                .Select(cm => cm.DayOfWeek!.Value)
                .ToListAsync();

            return usedDays;
        }
        #endregion

        #region Modules (Add/Sync/Update/Delete)
        public async Task AddModuleToCourse(int moduleId, 
            int courseId, int semester, DayOfWeek? dayOfWeek = null)
        {
            var exists = await _context.CourseModules
                .FirstOrDefaultAsync(cm => cm.ModuleID == moduleId &&
                                    cm.CourseID == courseId);

            if (exists != null)
            {
                exists.Semester = semester;
                exists.DayOfWeek = dayOfWeek;
                _context.CourseModules.Update(exists);
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
            }

            await _context.SaveChangesAsync();
        }

        public async Task SyncModuleCourses(int moduleId, int[] courseIds, int[] semesters, DayOfWeek[] daysOfWeek)
        {
            var current = await GetByModuleId(moduleId);

            foreach (var cm in current)
            {
                if (!courseIds.Contains(cm.CourseID))
                    _context.CourseModules.Remove(cm);
            }

            for (int i = 0; i < courseIds.Length; i++)
                await AddModuleToCourse(moduleId, courseIds[i], semesters[i], daysOfWeek[i]);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateModuleInCourse(int courseId, int moduleId, int semester, DayOfWeek? dayOfWeek = null)
        {
            var cm = await _context.CourseModules
                .FirstOrDefaultAsync(c => c.CourseID == courseId &&
                                        c.ModuleID == moduleId);

            if (cm != null)
            {
                cm.Semester = semester;
                cm.DayOfWeek = dayOfWeek;

                _context.CourseModules.Update(cm);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveModuleFromCourse(int courseId, int moduleId)
        {
            var courseModule = await _context.CourseModules
                .FirstOrDefaultAsync(cm => cm.CourseID == courseId && cm.ModuleID == moduleId);

            if (courseModule != null)
            {
                _context.CourseModules.Remove(courseModule);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
