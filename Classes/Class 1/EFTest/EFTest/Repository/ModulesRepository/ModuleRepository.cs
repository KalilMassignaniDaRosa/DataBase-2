using EFTest.Data;
using EFTest.Models.Modules;
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
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Queries
        public async Task<Module?> GetById(int id)
        {
            var module = await _context.Modules
                .Include(m => m.CourseModules)
                .Include(m => m.Prerequisites)
                .Include(m => m.IsPrerequisiteFor)
                .FirstOrDefaultAsync(m => m.ID == id);

            return module;
        }

        public async Task<List<Module>> GetAll()
        {
            var modules = await _context.Modules
                .OrderBy(m => m.Name)
                .ToListAsync();

            return modules;
        }

        public async Task<List<Module>> GetByName(string name)
        {
            var modules = await _context.Modules
                .Where(m => m.Name != null &&
                            EF.Functions.Like(m.Name, $"%{name}%"))
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

        public async Task<List<Module>> GetWithPrerequisites()
        {
            var modules = await _context.Modules
                .Include(m => m.Prerequisites!)
                .ThenInclude(p => p.Prerequisite)
                .ToListAsync();

            return modules;
        }
        #endregion
    }
}
