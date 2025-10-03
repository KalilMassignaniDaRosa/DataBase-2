using EFTest.Models.Students;
using System.ComponentModel.DataAnnotations;

namespace EFTest.Models.Courses
{
    public class Course
    {
        // Notacao do EF para explicitar
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int NumberOfSemesters { get; set; }

        // Relacionamentos
        public List<StudentCourse>? StudentCourses { get; set; }
        public List<CourseModule>? CourseModules { get; set; }
    }
}
