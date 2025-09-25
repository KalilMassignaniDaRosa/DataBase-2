using EFTest.Models;
using System.Diagnostics;

namespace EFTest.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Procura estudantes
            if (context.Students.Any())
            {
                return;  
            }

            var students = new Student[]
            {
                new() {FirstMidName="Matheus",LastName="Fribel",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new() {FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new() {FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new() {FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new() {FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new() {FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
                new() {FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new() {FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }

            context.SaveChanges();

            // Semeando cursos
            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                    new() { Name = "Computer Science", CreationDate = DateTime.Parse("2024-01-10") },
                    new() { Name = "Mathematics", CreationDate = DateTime.Parse("2024-02-05") },
                    new() { Name = "Physics", CreationDate = DateTime.Parse("2024-03-01") },
                    new() { Name = "Chemistry", CreationDate = DateTime.Parse("2024-03-25") },
                    new() { Name = "Biology", CreationDate = DateTime.Parse("2024-04-20") },
                    new() { Name = "English Literature", CreationDate = DateTime.Parse("2024-05-15") },
                    new() { Name = "History", CreationDate = DateTime.Parse("2024-06-10") },
                    new() { Name = "Philosophy", CreationDate = DateTime.Parse("2024-07-05") }
                };

                foreach (Course c in courses)
                {
                    context.Courses.Add(c);
                }

                context.SaveChanges();
            }

            // Criando relaçoes Student-Course
            if (!context.StudentCourses.Any())
            {
                var studentCourses = new StudentCourses[]
                {
                    new() { StudentID = students[0].ID, CourseID = 1, SignDate = DateTime.Parse("2024-08-01") },
                    new() { StudentID = students[0].ID, CourseID = 2, SignDate = DateTime.Parse("2024-08-03") },
                    new() { StudentID = students[1].ID, CourseID = 1, SignDate = DateTime.Parse("2024-08-04") },
                    new() { StudentID = students[2].ID, CourseID = 3, SignDate = DateTime.Parse("2024-08-06"), CancelDate = DateTime.Parse("2024-09-01") },
                    new() { StudentID = students[3].ID, CourseID = 4, SignDate = DateTime.Parse("2024-08-08") },
                    new() { StudentID = students[4].ID, CourseID = 5, SignDate = DateTime.Parse("2024-08-10") },
                    new() { StudentID = students[5].ID, CourseID = 6, SignDate = DateTime.Parse("2024-08-12") },
                    new() { StudentID = students[6].ID, CourseID = 7, SignDate = DateTime.Parse("2024-08-14") },
                    new() { StudentID = students[7].ID, CourseID = 8, SignDate = DateTime.Parse("2024-08-16") },
                    new() { StudentID = students[2].ID, CourseID = 2, SignDate = DateTime.Parse("2024-08-18") },
                    new() { StudentID = students[4].ID, CourseID = 1, SignDate = DateTime.Parse("2024-08-20") }
                };

                foreach (var sc in studentCourses)
                {
                    context.StudentCourses.Add(sc);
                }

                context.SaveChanges();
            }
        }
    }
}
