using EFTest.Data;
using EFTest.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.StudentsRepository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context) => _context = context;

        #region Basic Operations
        public async Task Create(Student student)
        {
            object value = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            var existingStudent = await _context.Students
                .FirstOrDefaultAsync(s => s.ID == student.ID);

            if (existingStudent != null)
            {
                _context.Entry(existingStudent).CurrentValues.SetValues(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(Student student)
        {
            // Remove nao tem asyc
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Queries
        // Task permite fazer uma funcao assincrona
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

        public async Task<List<Student>> GetByName(string sName)
        {
            var students = await _context.Students
               .Where(s => s.FirstMidName != null &&
               // Sugestao da IDE
               s.FirstMidName.Contains(sName, StringComparison.CurrentCultureIgnoreCase))
               .ToListAsync();

            return students;
        }
        #endregion
    }
}
