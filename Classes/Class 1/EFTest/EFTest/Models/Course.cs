using System.ComponentModel.DataAnnotations;

namespace EFTest.Models
{
    public class Course
    {
        // Notacao do EF para explicitar
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public List<StudentCourses>? StudentCourses { get; set; }
    }
}
