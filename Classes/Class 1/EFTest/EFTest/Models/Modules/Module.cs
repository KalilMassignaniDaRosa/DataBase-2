using EFTest.Models.Courses;
using EFTest.Models.Students;
using System.ComponentModel.DataAnnotations;

namespace EFTest.Models.Modules
{
    public class Module
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }

        public int? WorkloadHours { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        // Relacionamentos
        public List<CourseModule>? CourseModules { get; set; }
        public List<StudentModule>? StudentModules { get; set; }

        // Self relaction
        public List<ModulePrerequisite>? Prerequisites { get; set; }
        public List<ModulePrerequisite>? IsPrerequisiteFor { get; set; }
    }
}
