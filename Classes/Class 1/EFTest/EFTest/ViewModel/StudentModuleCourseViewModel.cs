using EFTest.Models.Courses;
using EFTest.Models.Modules;
using EFTest.Models.Students;
using System.Collections.Generic;
using System.Linq;

namespace EFTest.ViewModel
{
    // DTO que a view vai consumir
    public class ModuleOptionVm
    {
        public int ID { get; set; }
        public string Name { get; set; } = "";
        public DayOfWeek? DayOfWeek { get; set; }
        public int Semester { get; set; }
        public List<string> Prerequisites { get; set; } = new();
    }

    public class StudentModuleCourseViewModel
    {
        public Student Student { get; set; } = null!;
        public Course Course { get; set; } = null!;
        public List<Module> AllModules { get; set; } = new();

        // Materias que o aluno pode pegar
        public IEnumerable<ModuleOptionVm> GetAvailableModules()
        {
            if (Course?.CourseModules == null) return Enumerable.Empty<ModuleOptionVm>();

            // Dados do aluno
            var studentModuleIdsInCourse = Student.StudentModules?
                .Where(sm => sm.CourseID == Course.ID && sm.CancelDate == null)
                .Select(sm => sm.ModuleID)
                .ToHashSet() ?? new HashSet<int>();

            var occupiedDays = Student.StudentModules?
                .Where(sm => sm.CancelDate == null && sm.DayOfWeek.HasValue)
                .Select(sm => sm.DayOfWeek!.Value)
                .ToHashSet() ?? new HashSet<DayOfWeek>();

            var completedModuleIds = Student.StudentModules?
                .Where(sm => sm.Status == ModuleStatusEnum.Approved)
                .Select(sm => sm.ModuleID)
                .ToHashSet() ?? new HashSet<int>();

            bool requireOddSemester = DateTime.Now.Month <= 6;

            var list = new List<ModuleOptionVm>();

            foreach (var cm in Course.CourseModules!)
            {
                var module = cm.Module;
                if (module == null) continue;

                // Verifica condicoes
                bool alreadyInCourse = studentModuleIdsInCourse.Contains(module.ID);
                // Se ja esta inscrito no mesmo curso
                if (alreadyInCourse) 
                    continue;

                // Se o semestre esta certo
                if (cm.Semester > 0)
                {
                    bool isOdd = (cm.Semester % 2 == 1);
                    if (isOdd != requireOddSemester) 
                        continue;
                }

                // Se o dia esta disponivel
                if (cm.DayOfWeek.HasValue && occupiedDays.Contains(cm.DayOfWeek.Value)) 
                    continue; 

                // Se cumpriui os prerequisitos
                if (module.Prerequisites != null && module.Prerequisites.Any())
                {
                    var missing = module.Prerequisites
                        .Where(p => !completedModuleIds.Contains(p.PrerequisiteID))
                        .ToList();
                    if (missing.Any()) 
                        continue; 
                }

                // Disponivel
                list.Add(new ModuleOptionVm
                {
                    ID = module.ID,
                    Name = module.Name ?? "",
                    DayOfWeek = cm.DayOfWeek,
                    Semester = cm.Semester,
                    Prerequisites = (module.Prerequisites ?? Enumerable.Empty<ModulePrerequisite>())
                                    .Select(p => p.Prerequisite?.Name ?? $"#{p.PrerequisiteID}")
                                    .ToList()
                });
            }

            return list.OrderBy(m => m.Semester).ThenBy(m => m.Name);
        }

        // Materias que o aluno nao pode pegar + motivo
        public IEnumerable<(ModuleOptionVm Module, string Reason)> GetUnavailableModules()
        {
            if (Course?.CourseModules == null) return Enumerable.Empty<(ModuleOptionVm, string)>();

            var studentModuleIdsInCourse = Student.StudentModules?
                .Where(sm => sm.CourseID == Course.ID && sm.CancelDate == null)
                .Select(sm => sm.ModuleID)
                .ToHashSet() ?? new HashSet<int>();

            var occupiedDays = Student.StudentModules?
                .Where(sm => sm.CancelDate == null && sm.DayOfWeek.HasValue)
                .Select(sm => sm.DayOfWeek!.Value)
                .ToHashSet() ?? new HashSet<DayOfWeek>();

            var completedModuleIds = Student.StudentModules?
                .Where(sm => sm.Status == ModuleStatusEnum.Approved)
                .Select(sm => sm.ModuleID)
                .ToHashSet() ?? new HashSet<int>();

            bool requireOddSemester = DateTime.Now.Month <= 6;

            var list = new List<(ModuleOptionVm Module, string Reason)>();

            foreach (var cm in Course.CourseModules!)
            {
                var module = cm.Module;
                if (module == null) continue;

                var vm = new ModuleOptionVm
                {
                    ID = module.ID,
                    Name = module.Name ?? "",
                    DayOfWeek = cm.DayOfWeek,
                    Semester = cm.Semester,
                    Prerequisites = (module.Prerequisites ?? Enumerable.Empty<ModulePrerequisite>())
                                    .Select(p => p.Prerequisite?.Name ?? $"#{p.PrerequisiteID}")
                                    .ToList()
                };

                var reasons = new List<string>();

                if (studentModuleIdsInCourse.Contains(module.ID))
                    reasons.Add("Already enrolled in this course");

                if (cm.Semester > 0)
                {
                    bool isOdd = (cm.Semester % 2 == 1);
                    if (isOdd != requireOddSemester)
                        reasons.Add($"Semester {cm.Semester} not available in current period");
                }

                if (cm.DayOfWeek.HasValue && occupiedDays.Contains(cm.DayOfWeek.Value))
                    reasons.Add($"Day conflict ({cm.DayOfWeek.Value})");

                if (module.Prerequisites != null && module.Prerequisites.Any())
                {
                    var missing = module.Prerequisites
                        .Where(p => !completedModuleIds.Contains(p.PrerequisiteID))
                        .Select(p => p.Prerequisite?.Name ?? $"#{p.PrerequisiteID}")
                        .ToList();

                    if (missing.Any())
                        reasons.Add("Missing prerequisite(s): " + string.Join(", ", missing));
                }

                if (reasons.Any())
                    list.Add((Module: vm, Reason: string.Join("; ", reasons)));
            }

            return list.OrderBy(x => x.Module.Semester)
                       .ThenBy(x => x.Module.Name);
        }
    }
}
