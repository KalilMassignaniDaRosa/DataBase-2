using EFTest.Models.Courses;

namespace EFTest.Repository.CoursesRepository
{
    public interface ICourseRepository
    {
        // Opercoes basicas
        public Task Create(Course course);
        public Task Update(Course course);
        public Task Delete(Course course);

        // Consultas
        public Task<Course?> GetById(int id, bool includeModules = false, bool includeStudents = false);
        public Task<List<Course>> GetAll(bool includeModules = false, bool includeStudents = false);
        public Task<List<Course>> GetByName(string name);

        // Filtro avancado
        public Task<Course?> GetByIdWithModulesAndPrerequisites(int id);
    }
}
