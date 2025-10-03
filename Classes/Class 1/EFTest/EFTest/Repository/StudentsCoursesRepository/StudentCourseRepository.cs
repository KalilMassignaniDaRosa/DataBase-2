using EFTest.Data;
using EFTest.Models.Courses;
using EFTest.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.StudentsCoursesRepository
{
    public class StudentCourseRepository : IStudentCourseRepository
    {
        private readonly SchoolContext _context;

        public StudentCourseRepository(SchoolContext context) => _context = context;

        #region Basic Operations
        public async Task Create(StudentCourse studentCourse)
        {
            await _context!.StudentCourses.AddAsync(studentCourse);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(StudentCourse studentCourse)
        {
            _context!.StudentCourses.Remove(studentCourse);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Queries
        public async Task<StudentCourse?> GetByIds(int studentId, int courseId)
        {
            var studentCourse = await _context!.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .FirstOrDefaultAsync(sc =>
                    sc.StudentID == studentId &&
                    sc.CourseID == courseId);

            return studentCourse;
        }

        public async Task<List<StudentCourse>> GetAll()
        {
            var studentCourses = await _context!.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .ToListAsync();

            return studentCourses;
        }

        public async Task<List<StudentCourse>> GetByStudentId(int studentId, 
            bool includeCanceled = false)
        {
            var query = _context.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .Where(sc => sc.StudentID == studentId);

            if (!includeCanceled)
                query = query.Where(sc => sc.CancelDate == null);

            var studentCourses = await query.ToListAsync();

            return studentCourses;
        }

        public async Task<List<StudentCourse>> GetByCourseId(int courseId)
        {
            var studentCourses = await _context!.StudentCourses
                .Include(sc => sc.Student)
                .Include(sc => sc.Course)
                .Where(sc => sc.CourseID == courseId)
                .ToListAsync();

            return studentCourses;
        }

        public async Task<Student?> GetStudentByIdWithCourses(int studentId)
        {
            var student =  await _context!.Students
                .Include(s => s.StudentCourses!)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.ID == studentId);

            return student;
        }

        public async Task<Course?> GetCourseByIdWithStudents(int courseId)
        {
            var course = await _context!.Courses
                .Include(c => c.StudentCourses!)
                .ThenInclude(sc => sc.Student)
                .FirstOrDefaultAsync(c => c.ID == courseId);

            return course;
        }
        #endregion

        #region Enrollments (Add/Remove)
        public async Task AddCourseToStudent(int studentId, int courseId)
        {
            var exists = await _context!.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentID == studentId &&
                                        sc.CourseID == courseId);

            if (exists != null)
            {
                // Reativa se estivesse cancelado
                if (exists.CancelDate != null)
                {
                    exists.CancelDate = null;
                    exists.SignDate = DateTime.Now;
                    _context.StudentCourses.Update(exists);
                    await _context.SaveChangesAsync();
                }
                // Ja ativo
            }
            else
            {
                var sc = new StudentCourse
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
                .FirstOrDefaultAsync(sc => sc.StudentID == studentId 
                && sc.CourseID == courseId && sc.CancelDate == null);

            if (studentCourse != null)
            {
                studentCourse.CancelDate = DateTime.Now;
                _context.StudentCourses.Update(studentCourse);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
