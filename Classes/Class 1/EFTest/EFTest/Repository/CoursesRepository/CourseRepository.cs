using EFTest.Data;
using EFTest.Models.Courses;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.CoursesRepository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;

        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }

        #region Basic Operations
        public async Task Create(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Queries
        public async Task<Course?> GetById(int id,
            bool includeModules = false, bool includeStudents = false)
        {
            var query = _context.Courses.AsQueryable();

            // Garante as propriedades sejam carregadas
            query = query.AsNoTracking().Where(c => c.ID == id);

            if (includeModules)
                query = query.Include(c => c.CourseModules!)
                             .ThenInclude(cm => cm.Module);

            if (includeStudents)
                query = query.Include(c => c.StudentCourses!)
                             .ThenInclude(sc => sc.Student);

            var course = await query.FirstOrDefaultAsync();

            return course;
        }

        public async Task<List<Course>> GetAll(bool includeModules = false,
            bool includeStudents = false)
        {
            var query = _context.Courses.AsQueryable();

            if (includeModules)
                query = query.Include(c => c.CourseModules!)
                             .ThenInclude(cm => cm.Module);

            if (includeStudents)
                query = query.Include(c => c.StudentCourses!)
                             .ThenInclude(sc => sc.Student);

            var courses = await query.OrderBy(c => c.Name).ToListAsync();

            return courses;
        }

        public async Task<List<Course>> GetByName(string name)
        {
            var courses = await _context.Courses.
               Where(s => s.Name!.Contains(name, StringComparison.CurrentCultureIgnoreCase))
               .ToListAsync();

            return courses;
        }

        public async Task<Course?> GetByIdWithModulesAndPrerequisites(int id)
        {
            var course = await _context.Courses
                .Include(c => c.CourseModules)!
                    .ThenInclude(cm => cm.Module)!
                        .ThenInclude(m => m.Prerequisites)!
                            .ThenInclude(p => p.Prerequisite)
                .FirstOrDefaultAsync(c => c.ID == id);

            return course;
        }
        #endregion
    }
}
