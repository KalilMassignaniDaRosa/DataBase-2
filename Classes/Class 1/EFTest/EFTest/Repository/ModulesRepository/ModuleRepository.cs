using EFTest.Data;
using EFTest.Models.Modules;
using EFTest.Models.Students;
using Microsoft.EntityFrameworkCore;

namespace EFTest.Repository.ModulesRepository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly SchoolContext _context;

        public ModuleRepository(SchoolContext context) => _context = context;

        #region Basic Operations
        public async Task Create(Module module)
        {
            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Module module)
        {
            _context.Modules.Update(module);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Module module)
        {
            // Remove prerequisitos
            var prereqs = await _context.ModulePrerequisites
                .Where(mp => mp.ModuleID == module.ID || mp.PrerequisiteID == module.ID)
                .ToListAsync();

            _context.ModulePrerequisites.RemoveRange(prereqs);

            // Remove a materia
            _context.Modules.Remove(module);

            await _context.SaveChangesAsync();
        }
        #endregion

        #region Queries
        public async Task<Module?> GetById(int id,
            bool includeCourses = false, bool includePrerequisites = false)
        {
            var query = _context.Modules.AsQueryable();

            if (includeCourses)
                query = query.Include(m => m.CourseModules!)
                             .ThenInclude(cm => cm.Course);

            if (includePrerequisites)
                query = query.Include(m => m.Prerequisites!)
                             .ThenInclude(p => p.Prerequisite);

            var module = await query.FirstOrDefaultAsync(m => m.ID == id);

            return module;
        }

        public async Task<List<Module>> GetAll(bool includePrerequisites = false)
        {
            var query = _context.Modules.AsQueryable();

            if (includePrerequisites)
                query = query.Include(m => m.Prerequisites!)
                             .ThenInclude(p => p.Prerequisite);

            var modules = await query.OrderBy(m => m.Name).ToListAsync();

            return modules;
        }

        public async Task<List<Module>> GetByName(string name)
        {
            var modules = await _context.Modules
                // Busca semelhante
                .Where(m => m.Name != null && EF.Functions.Like(m.Name, $"%{name}%"))
                .ToListAsync();

            return modules;
        }

        public async Task<List<Module>> GetByCourseId(int courseId)
        {
            var modules = await _context.Modules
                .Include(m => m.CourseModules)
                .Where(m => m.CourseModules!.Any(cm => cm.CourseID == courseId))
                .ToListAsync();

            return modules;
        }

        public async Task<ICollection<StudentModule>> GetStudentModulesByModuleId(int moduleId)
        {
            return await _context.StudentModules
                .Include(sm => sm.Student)
                .Where(sm => sm.ModuleID == moduleId)
                .ToListAsync();
        }
        #endregion

        #region Prerequisite
        public async Task AddPrerequisite(int moduleId, int prerequisiteId)
        {
            var exists = await _context.ModulePrerequisites
                .FirstOrDefaultAsync(mp => mp.ModuleID == moduleId && mp.PrerequisiteID == prerequisiteId);

            if (exists != null)
                return;

            var mp = new ModulePrerequisite
            {
                ModuleID = moduleId,
                PrerequisiteID = prerequisiteId
            };

            await _context.ModulePrerequisites.AddAsync(mp);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAllPrerequisites(int moduleId)
        {
            var prerequisites = _context.ModulePrerequisites
                .Where(p => p.ModuleID == moduleId);

            _context.ModulePrerequisites.RemoveRange(prerequisites);

            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
