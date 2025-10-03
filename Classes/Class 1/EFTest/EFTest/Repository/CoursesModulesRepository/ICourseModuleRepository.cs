using EFTest.Models.Courses;
using EFTest.Models.Modules;

namespace EFTest.Repository.CoursesModulesRepository
{
    public interface ICourseModuleRepository
    {
        // Operacoes basicas
        public Task Create(CourseModule courseModule);
        public Task Delete(CourseModule courseModule);

        // Consultas
        public Task<CourseModule?> GetByIds(int courseId, int moduleId);
        public Task<List<CourseModule>> GetAll();

        // Filtro
        public Task<List<CourseModule>> GetByCourseId(int courseId, 
            DayOfWeek? dayOfWeek = null, int? semester = null);
        public Task<List<CourseModule>> GetByModuleId(int moduleId);

        // Filtro avancado
        public Task<List<CourseModule>> GetModulesByCourseIdAndDay(int courseId, 
            int semester, DayOfWeek? dayOfWeek = null);
        public Task<List<DayOfWeek>> GetUsedDaysByCourseAndSemester(int courseId, int semester);

        // Matricula
        public Task AddModuleToCourse(int moduleId, 
            int courseId, int semester, DayOfWeek? dayOfWeek = null);
        public Task SyncModuleCourses(int moduleId, 
            int[] courseIds, int[] semesters, DayOfWeek[] daysOfWeek);
        public Task UpdateModuleInCourse(int courseId, int moduleId, 
            int semester, DayOfWeek? dayOfWeek = null);
        public Task RemoveModuleFromCourse(int courseId, int moduleId);
    }
}
   
