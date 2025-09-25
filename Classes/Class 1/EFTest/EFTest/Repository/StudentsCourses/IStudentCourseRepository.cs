using EFTest.Models;

namespace EFTest.Repository.StudentsCourses
{
    public interface IStudentCourseRepository
    {
        public Task Create(StudentCourses studentCourse);
        // Nao tem Update porque e N:N
        public Task Delete(StudentCourses studentCourse);

        public Task<StudentCourses?> GetByIds(int studentId, int courseId);
        public Task<List<StudentCourses>> GetAll();

        public Task<List<StudentCourses>> GetByStudent(int studentId);
        public Task<List<StudentCourses>> GetByStudentWithCanceled(int studentId);

        public Task<Student?> GetStudentWithCourses(int studentId);

        public Task<List<StudentCourses>> GetByCourse(int courseId);
        public Task<Course?> GetCourseWithStudents(int courseId);

        public Task AddCourseToStudent(int studentId, int courseId);
        public Task RemoveCourseFromStudent(int studentId, int courseId);
    }
}
