using EFTest.Models.Modules;

namespace EFTest.Repository.ModulesRepository
{
    public interface IModuleRepository
    {
        public Task Create(Module module);
        public Task Update(Module module);
        public Task Delete(Module module);

        public Task<Module?> GetById(int id);
        public Task<List<Module>> GetAll();
        public Task<List<Module>> GetByName(string name);

        public Task<List<Module>> GetByCourseId(int courseId);
        public Task<List<Module>> GetWithPrerequisites();
    }
}
