using EFTest.Models.Students;

namespace EFTest.Repository.StudentsRepository
{
    public interface IStudentRepository
    {
        // Operacoes Basicas
        public Task Create(Student student);
        public Task Update(Student student);
        public Task Delete(Student student);

        // Consultas
        public Task<Student?> GetById(int id);
        public Task<List<Student>> GetAll();
        public Task<List<Student>> GetByName(string sName);
    }
}
