using EFTest.Models.Courses;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models.Students
{
    [PrimaryKey(nameof(StudentID), nameof(CourseID))]
    public class StudentCourse
    {
        public int StudentID { get; set; }
        // Property Navigations
        // Carrega os dados quando for mexer na matricula
        [ForeignKey(nameof(StudentID))]
        public Student? Student { get; set; }

        public int CourseID { get; set; }
        [ForeignKey(nameof(CourseID))]
        public Course? Course { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime? CancelDate { get; set; }

        public DateTime GetEstimatedEndDate()
        {
            int semesters = 0;
            if (Course != null)
                semesters = Course.NumberOfSemesters;

            int totalMonths = semesters * 6;
            DateTime estimatedEndDate = SignDate.AddMonths(totalMonths);

            return estimatedEndDate;
        }
    }
}
