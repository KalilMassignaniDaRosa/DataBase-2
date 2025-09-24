using EFTest.Data;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.Modules
{
    public class ModuleRepository : IModuleRepository
    {/*
        private readonly SchoolContext _context;

        public ModuleRepository(SchoolContext context)
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

        #region Getters
        public async Task<List<Course>> GetAll()
        {
            var data = await _context.Courses.ToListAsync();
            return data;
        }
        public async Task<Course> GetById(int id)
        {
            var course = await _context.Courses.
                Where(c => c.ID == id)
                .FirstOrDefaultAsync();

            return course!;
        }
        
        public async Task<List<Course>> GetByName(string name)
        {
            var courses = await _context.Courses.
               Where(s => s.Name!.ToLower().
               Contains(name.ToLower()))
               .ToListAsync();

            return courses;
        }

        public async Task<List<Course>> GetAllWithStudents()
        {
            var courses = await _context.Courses
                .Include(c => c.StudentCourses!)
                .ThenInclude(sc => sc.Student)
                .ToListAsync();

            // Ordena os alunos de cada curso
            foreach (var course in courses)
            {
                course.StudentCourses = course.StudentCourses!
                    .OrderBy(sc => sc.Student!.FirstMidName)
                    .ThenBy(sc => sc.Student!.LastName)
                    .ToList();
            }

            return courses;
        }
        #endregion
        */
    }
}
