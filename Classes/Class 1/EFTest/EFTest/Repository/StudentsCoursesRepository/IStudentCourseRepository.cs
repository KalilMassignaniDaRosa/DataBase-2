using EFTest.Models.Courses;
using EFTest.Models.Students;

namespace EFTest.Repository.StudentsCoursesRepository
{
    public interface IStudentCourseRepository
    {
        public Task Create(StudentCourse studentCourse);
        // Nao tem Update porque e N:N
        public Task Delete(StudentCourse studentCourse);

        // StudentCourse
        public Task<StudentCourse?> GetByIds(int studentId, int courseId);
        public Task<List<StudentCourse>> GetAll();

        public Task<List<StudentCourse>> GetByStudentId(int studentId);
        public Task<List<StudentCourse>> GetByCourseId(int courseId);
        public Task<List<StudentCourse>> GetByStudentIdWithCanceled(int studentId);

        // Course e student
        public Task<Student?> GetStudentByIdWithCourses(int studentId);
        public Task<Course?> GetCourseByIdWithStudents(int courseId);

        // Matriculas
        public Task AddCourseToStudent(int studentId, int courseId);
        public Task RemoveCourseFromStudent(int studentId, int courseId);
    }
}
