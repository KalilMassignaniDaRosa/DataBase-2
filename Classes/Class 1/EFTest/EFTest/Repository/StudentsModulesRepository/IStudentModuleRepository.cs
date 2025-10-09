using EFTest.Models.Courses;
using EFTest.Models.Modules;
using EFTest.Models.Students;

namespace EFTest.Repository.StudentsModulesRepository
{
    public interface IStudentModuleRepository
    {
        // Operacoes basicas
        public Task Update(StudentModule studentModule);

        // Consultas
        public Task<StudentModule?> GetByIds(int studentId, int moduleId, int courseId);
        public Task<List<StudentModule>> GetByStudentId(int studentId);
        public Task<List<StudentModule>> GetByStudentAndCourse(int studentId, int courseId);
        public Task<CourseModule?> GetCourseModule(int courseId, int moduleId);

        // Modules
        public Task AddModuleToStudent(int studentId, int moduleId, int courseId, DayOfWeek? dayOfWeek = null);
        public Task RemoveModuleFromStudent(int studentId, int moduleId);
    }
}
