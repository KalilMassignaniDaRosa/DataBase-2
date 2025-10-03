using EFTest.Models.Courses;
using EFTest.Models.Students;

namespace EFTest.Repository.StudentsCoursesRepository
{
    public interface IStudentCourseRepository
    {
        // Operacoes basicas
        public Task Create(StudentCourse studentCourse);
        // Nao tem Update porque e N:N
        public Task Delete(StudentCourse studentCourse);

        // Consulta
        public Task<StudentCourse?> GetByIds(int studentId, int courseId);
        public Task<List<StudentCourse>> GetAll();

        // Filtro
        public Task<List<StudentCourse>> GetByStudentId(int studentId, bool includeCanceled = false);
        public Task<List<StudentCourse>> GetByCourseId(int courseId);

        // Filtro avancado
        public Task<Student?> GetStudentByIdWithCourses(int studentId);
        public Task<Course?> GetCourseByIdWithStudents(int courseId);

        // Matricula
        public Task AddCourseToStudent(int studentId, int courseId);
        public Task RemoveCourseFromStudent(int studentId, int courseId);
    }
}
