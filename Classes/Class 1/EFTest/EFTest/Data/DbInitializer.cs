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
            new Student{FirstMidName="Matheus",LastName="Fribel",EnrollmentDate=DateTime.Parse("2005-09-01")},
            new Student{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
            new Student{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
            new Student{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
            new Student{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
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
                    new Course{ Name = "Computer Science" },   
                    new Course{ Name = "Mathematics" },
                    new Course{ Name = "Physics" },
                    new Course{ Name = "Chemistry" },
                    new Course{ Name = "Biology" },
                    new Course{ Name = "English Literature" },
                    new Course{ Name = "History" },
                    new Course{ Name = "Philosophy" }
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
                    new StudentCourses { StudentID = students[0].ID, CourseID = 1 },
                    new StudentCourses { StudentID = students[0].ID, CourseID = 2 },
                    new StudentCourses { StudentID = students[1].ID, CourseID = 1 },
                    new StudentCourses { StudentID = students[2].ID, CourseID = 3 },
                    new StudentCourses { StudentID = students[3].ID, CourseID = 4 },
                    new StudentCourses { StudentID = students[4].ID, CourseID = 5 },
                    new StudentCourses { StudentID = students[5].ID, CourseID = 6 },
                    new StudentCourses { StudentID = students[6].ID, CourseID = 7 },
                    new StudentCourses { StudentID = students[7].ID, CourseID = 8 },
                    new StudentCourses { StudentID = students[2].ID, CourseID = 2 },
                    new StudentCourses { StudentID = students[4].ID, CourseID = 1 }
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
