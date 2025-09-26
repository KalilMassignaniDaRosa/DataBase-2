using System.ComponentModel.DataAnnotations;

namespace EFTest.Models.Students
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string? LastName { get; set; }
        public string? FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public List<StudentCourse>? StudentCourses { get; set; }
        public List<StudentModule>? StudentModules { get; set; }
    }
}
