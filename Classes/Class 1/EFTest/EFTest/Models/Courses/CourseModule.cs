using EFTest.Models.Modules;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models.Courses
{
    [PrimaryKey(nameof(CourseID), nameof(ModuleID))]
    public class CourseModule
    {
        public int CourseID { get; set; }
        [ForeignKey(nameof(CourseID))]
        public Course? Course { get; set; }

        public int ModuleID { get; set; }
        [ForeignKey(nameof(ModuleID))]
        public Module? Module { get; set; }

        public int Semester { get; set; }
        // DayOfWeek e um enum do dotnet
        public DayOfWeek? DayOfWeek { get; set; }
    }
}
