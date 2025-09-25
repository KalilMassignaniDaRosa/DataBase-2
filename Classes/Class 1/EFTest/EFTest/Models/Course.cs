using System.ComponentModel.DataAnnotations;

namespace EFTest.Models
{
    public class Course
    {
        // Notacao do EF para explicitar
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public int NumberOfSemesters { get; set; }
        public double? AverageGrade { get; set; }
        public double? AverageFrequency { get; set; }
        public List<StudentCourses>? StudentCourses { get; set; }
    }
}
