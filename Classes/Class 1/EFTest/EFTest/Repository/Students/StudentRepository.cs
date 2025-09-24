using EFTest.Data;
using EFTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.Students
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context) => _context = context;

        #region Basic Operations
        public async Task Create(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            // remove não tem asyc
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task AddCourseToStudent(int studentId, int courseId)
        {
            // Verifica se a existe
            var exists = await _context.StudentCourses
                .AnyAsync(sc => sc.StudentID == studentId && sc.CourseID == courseId);

            if (!exists)
            {
                var studentCourse = new StudentCourses
                {
                    StudentID = studentId,
                    CourseID = courseId
                };

                await _context.StudentCourses.AddAsync(studentCourse);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCourseFromStudent(int studentId, int courseId)
        {
            var sc = await _context.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentID == studentId && sc.CourseID == courseId);

            if (sc != null)
            {
                _context.StudentCourses.Remove(sc);
                await _context.SaveChangesAsync();
            }
        }

        #endregion

        #region Getters
        // Task permite fazer uma função assincrona
        public async Task<Student> GetById(int id)
        {
            var student = await _context.Students.
                Where(s => s.ID == id)
                .FirstOrDefaultAsync();

            return student!;
        }

        public async Task<List<Student>> GetAll()
        {
            var data = await _context.Students.ToListAsync();

            return data;
        }  

        public async Task<List<Student>> GetByStudentName(string sName)
        {
            var students = await _context.Students
               .Where(s => s.FirstMidName != null &&
               // Sugestao da IDE
               s.FirstMidName.Contains(sName, StringComparison.CurrentCultureIgnoreCase))
               .ToListAsync();

            return students;
        }

        public async Task<List<Student>> GetAllWithCourses()
        {
            var students = await _context.Students
                // Carrega a collection StudenCourses
                .Include(s => s.StudentCourses!)
                // Para cada um pega o Course
                .ThenInclude(sc => sc.Course)
                .ToListAsync();

            return students;
        }

        public async Task<Student> GetByIdWithCourses(int id)
        {
            var student = await _context.Students
                .Include(s => s.StudentCourses!)
                .ThenInclude(sc => sc.Course)
                .FirstOrDefaultAsync(s => s.ID == id);

            return student!;
        }
        #endregion
    }
}
