using EFTest.Models.Courses;
using EFTest.Models.Modules;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models.Students
{
    // Chave composta tripla
    [PrimaryKey(nameof(StudentID), nameof(ModuleID), nameof(CourseID))]
    public class StudentModule
    {
        public int StudentID { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student? Student { get; set; }

        public int ModuleID { get; set; }
        [ForeignKey(nameof(ModuleID))]
        public Module? Module { get; set; }

        public int CourseID { get; set; }
        [ForeignKey(nameof(CourseID))]
        public Course? Course { get; set; }

        public double? Grade { get; set; }
        public double? Frequency { get; set; }
        public DayOfWeek? DayOfWeek { get; set; }

        public DateTime SignDate { get; set; } = DateTime.UtcNow;
        public DateTime? CancelDate { get; set; }
        public ModuleStatusEnum Status { get; set; } = ModuleStatusEnum.NotTaken;
    }
}
