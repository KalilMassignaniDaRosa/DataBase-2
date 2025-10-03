using EFTest.Models.Students;

namespace EFTest.Repository.StudentsModulesRepository
{
    public interface IStudentModuleRepository
    {
        // Operacoes basicas
        public Task AddModuleToStudent(int studentId, int moduleId);
        public Task RemoveModuleFromStudent(int studentId, int moduleId);

        // Consultas
        public Task<List<StudentModule>> GetByStudentId(int studentId);
        public Task<List<StudentModule>> GetByStudentAndCourse(int studentId, int courseId);

        // Filtro
        public Task<bool> HasCompletedPrerequisite(int studentId, int prerequisiteModuleId);
        public Task<List<DayOfWeek>> GetUsedDaysByStudentAndCourse(int studentId, int courseId);
    }
}
