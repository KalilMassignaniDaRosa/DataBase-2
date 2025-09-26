using EFTest.Models.Courses;
using EFTest.Models.Modules;

namespace EFTest.Repository.CoursesModulesRepository
{
    public interface ICourseModuleRepository
    {
        public Task Create(CourseModule courseModule);
        public Task Delete(CourseModule courseModule);

        // CourseModule
        public Task<CourseModule?> GetByIds(int courseId, int moduleId);
        public Task<List<CourseModule>> GetAll();

        public Task<List<CourseModule>> GetByCourseId(int courseId);
        public Task<List<CourseModule>> GetByModuleId(int moduleId);

        // Course e Module
        public Task<Course?> GetCourseByIdWithModules(int courseId);
        public Task<Module?> GetModuleByIdWithCourses(int moduleId);

        // Matriculas
        public Task AddModuleToCourse(int moduleId, int courseId, int semester, DayOfWeek? dayOfWeek = null);
        public Task UpdateCourses(int moduleId, int[] courseIds, int[] semesters, DayOfWeek[] daysOfWeek);
    }
}
   
