using EFTest.Data;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.StudentsCourses
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly SchoolContext? _context;

        public StudentCourseRepository(SchoolContext? context) => _context = context;

        #region Basic Operations
        public async Task Create(StudentCourses studentCourse)
        {
            await _context!.StudentCourses.AddAsync(studentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(StudentCourses studentCourse)
        {
            _context!.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Getters
        public async Task<StudentCourses?> GetByIds(int studentId, int courseId)
        {
            var studentCourse = await _context!.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .FirstOrDefaultAsync(sc =>
                    sc.StudentID == studentId &&
                    sc.CourseID == courseId);

            return studentCourse;
        }

        public async Task<List<StudentCourses>> GetAll()
        {
            var studentCourses = await _context!.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .ToListAsync();

            return studentCourses;
        }

        public async Task<List<StudentCourses>> GetByStudent(int studentId)
        {
            var studentCourses = await _context!.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .Where(sc => sc.StudentID == studentId)
                .ToListAsync();

            return studentCourses;
        }

        public async Task<List<StudentCourses>> GetByCourse(int courseId)
        {
            var studentCourses = await _context!.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .Where(sc => sc.CourseID == courseId)
                .ToListAsync();

            return studentCourses;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            var courses = await _context!.Courses
                .OrderBy(c => c.Name)
                .ToListAsync();

            return courses;
        }
        #endregion

        #region Associate/Disassociate
        public async Task AddCourseToStudent(int studentId, int courseId)
        {
            var exists = await _context!.StudentCourses
                // AnyAsync e do EF
                // Verifica se tem um registro no DB com a condicao
                .AnyAsync(sc => sc.StudentID == studentId && sc.CourseID == courseId);

            if (!exists)
            {
                var sc = new StudentCourses
                {
                    StudentID = studentId,
                    CourseID = courseId,
                    SignDate = DateTime.Now,   
                    CancelDate = null
                };
                await _context.StudentCourses.AddAsync(sc);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCourseFromStudent(int studentId, int courseId)
        {
            var studentCourse = await _context!.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentID == studentId && sc.CourseID == courseId);

            if (studentCourse != null)
            {
                studentCourse.CancelDate = DateTime.Now;
                _context.StudentCourses.Remove(studentCourse);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
