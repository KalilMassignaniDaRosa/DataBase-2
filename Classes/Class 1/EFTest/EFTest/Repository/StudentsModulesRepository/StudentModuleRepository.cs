using EFTest.Data;
using EFTest.Models.Courses;
using EFTest.Models.Modules;
using EFTest.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.StudentsModulesRepository
{
    public class StudentModuleRepository: IStudentModuleRepository
    {
        private readonly SchoolContext _context;

        public StudentModuleRepository(SchoolContext context) => _context = context;

        #region Basic Operations
        public async Task Update(StudentModule studentModule)
        {
            _context.StudentModules.Update(studentModule);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Queries
        public async Task<StudentModule?> GetByIds(int studentId, int moduleId, int courseId)
        {
            var studentModule = await _context.StudentModules
                .Include(sm => sm.Student)
                .Include(sm => sm.Module)
                .Include(sm => sm.Course)
                .FirstOrDefaultAsync(sm => sm.StudentID == studentId &&
                                         sm.ModuleID == moduleId &&
                                         sm.CourseID == courseId);

            return studentModule;
        }

        public async Task<List<StudentModule>> GetByStudentId(int studentId)
        {
            var studentModules = await _context.StudentModules
                .Include(sm => sm.Module)
                .Include(sm => sm.Course)
                .Where(sm => sm.StudentID == studentId && sm.CancelDate == null)
                .ToListAsync();

            return studentModules;
        }

        public async Task<List<StudentModule>> GetByStudentAndCourse(int studentId, int courseId)
        {
            var studentModules = await _context.StudentModules
                .Include(sm => sm.Module)
                .Where(sm => sm.StudentID == studentId && sm.CourseID == courseId && sm.CancelDate == null)
                .ToListAsync();

            return studentModules;
        }

        public async Task<CourseModule?> GetCourseModule(int courseId, int moduleId)
        {
            var courseModule = await _context.CourseModules
                .Include(cm => cm.Module)
                .FirstOrDefaultAsync(cm => cm.CourseID == courseId && cm.ModuleID == moduleId);

            return courseModule;
        }
        #endregion

        #region Modules (Add/Remove)
        public async Task AddModuleToStudent(int studentId, int moduleId, int courseId, DayOfWeek? dayOfWeek = null)
        {
            var exists = await _context.StudentModules
                .FirstOrDefaultAsync(sm => sm.StudentID == studentId &&
                                         sm.ModuleID == moduleId &&
                                         sm.CourseID == courseId);

            if (exists != null)
            {
                // Reativa se estiver cancelado
                if (exists.CancelDate != null)
                {
                    exists.CancelDate = null;
                    exists.Status = ModuleStatusEnum.Enrolled;
                    exists.SignDate = DateTime.Now;
                    exists.DayOfWeek = dayOfWeek;
                    _context.StudentModules.Update(exists);
                }
                // Se ja existe e ativo, nao faz nada
            }
            else
            {
                var studentModule = new StudentModule
                {
                    StudentID = studentId,
                    ModuleID = moduleId,
                    CourseID = courseId,
                    DayOfWeek = dayOfWeek,
                    SignDate = DateTime.Now,
                    Status = ModuleStatusEnum.Enrolled
                };

                await _context.StudentModules.AddAsync(studentModule);
            }

            await _context.SaveChangesAsync();
        }

        public async Task RemoveModuleFromStudent(int studentId, int moduleId)
        {
            var studentModule = await _context.StudentModules
                .FirstOrDefaultAsync(sm => sm.StudentID == studentId &&
                                         sm.ModuleID == moduleId &&
                                         sm.CancelDate == null);

            if (studentModule != null)
            {
                studentModule.CancelDate = DateTime.UtcNow;
                studentModule.Status = ModuleStatusEnum.Canceled;
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
