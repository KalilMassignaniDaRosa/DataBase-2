using EFTest.Models.Modules;
using EFTest.Models.Students;

namespace EFTest.Repository.ModulesRepository
{
    public interface IModuleRepository
    {
        // Operacoes basicas
        public Task Create(Module module);
        public Task Update(Module module);
        public Task Delete(Module module);

        // Consultas
        public Task<Module?> GetById(int id, bool includeCourses = false, 
            bool includePrerequisites = false);
        public Task<List<Module>> GetAll(bool includePrerequisites = false);
        public Task<List<Module>> GetByName(string name);
        public Task<List<Module>> GetByCourseId(int courseId);
        public Task<ICollection<StudentModule>> GetStudentModulesByModuleId(int moduleId);

        // Matricula
        public Task AddPrerequisite(int moduleId, int prerequisiteId);
        public Task RemoveAllPrerequisites(int moduleId);
    }
}
