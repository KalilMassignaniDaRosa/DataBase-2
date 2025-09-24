using EFTest.Models;

namespace EFTest.Repository
{
    public interface IStudentRepository
    {
        public Task Create(Student student);
        public Task Update(Student student);
        public Task Delete(Student student);

        public Task<StudentCourses> GetByStudentId(int studentId);
        public Task<StudentCourses> GetByCourseId(int courseId);
        public Task<StudentCourses> Get(int studentId, int courseId);

        public Task<Student>? GetById(int id);
        public Task<List<Student>> GetAll();
        public Task<List<Student>> GetByCourseName(string name);
        public Task<List<Student>> GetByStudentName(string name);
        public Task<List<Student>> GetAllWithCourses();
        public Task<Student> GetByIdWithCourses(int id);


        public Task AddCourseToStudent(int studentId, int courseId);
        public Task RemoveCourseFromStudent(int studentId, int courseId);

    }
}
