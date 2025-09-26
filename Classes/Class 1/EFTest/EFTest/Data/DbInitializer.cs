using EFTest.Models.Courses;
using EFTest.Models.Students;
using EFTest.Models.Modules;
using System.Diagnostics;

namespace EFTest.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            #region Student
            // Procura estudante
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
            #endregion

            #region Courses
            if (!context.Courses.Any())
            {
                var courses = new Course[]
                {
                    new() { Name = "Computer Science", CreationDate = DateTime.Parse("2024-01-10"), NumberOfSemesters = 8 },
                    new() { Name = "Mathematics", CreationDate = DateTime.Parse("2024-02-05"), NumberOfSemesters = 6 },
                    new() { Name = "Physics", CreationDate = DateTime.Parse("2024-03-01"), NumberOfSemesters = 6 },
                    new() { Name = "Chemistry", CreationDate = DateTime.Parse("2024-03-25"), NumberOfSemesters = 6 },
                    new() { Name = "Biology", CreationDate = DateTime.Parse("2024-04-20"), NumberOfSemesters = 6 },
                    new() { Name = "English Literature", CreationDate = DateTime.Parse("2024-05-15"), NumberOfSemesters = 4 },
                    new() { Name = "History", CreationDate = DateTime.Parse("2024-06-10"), NumberOfSemesters = 4 },
                    new() { Name = "Philosophy", CreationDate = DateTime.Parse("2024-07-05"), NumberOfSemesters = 4 }
                };

                context.Courses.AddRange(courses);
                context.SaveChanges();
            }
            #endregion

            #region Modules
            if (!context.Modules.Any())
            {
                var modules = new Module[]
                {
                    // Ciencia da computacao
                    new() { Name = "Introduction to Programming", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-01") },
                    new() { Name = "Data Structures", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-01-02") },
                    new() { Name = "Algorithms", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-01-03") },
                    new() { Name = "Computer Architecture", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-04") },

                    // Matematica
                    new() { Name = "Calculus I", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-01") },
                    new() { Name = "Linear Algebra", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-02") },
                    new() { Name = "Discrete Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-03") },

                    // Fisica
                    new() { Name = "Classical Mechanics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-01") },
                    new() { Name = "Electromagnetism", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-02") },

                    // Quimica
                    new() { Name = "Organic Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-25") },
                    new() { Name = "Inorganic Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-26") },

                    // Biologia
                    new() { Name = "Cell Biology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-01") },
                    new() { Name = "Genetics", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-02") },

                    // Literatura Inglesa
                    new() { Name = "Shakespearean Literature", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-01") },
                    new() { Name = "Modern Poetry", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-02") },

                    // Historia
                    new() { Name = "World History I", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-01") },
                    new() { Name = "World History II", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-02") },

                    // Filosofia
                    new() { Name = "Ethics", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-01") },
                    new() { Name = "Logic", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-02") }
                };

                context.Modules.AddRange(modules);
                context.SaveChanges();
            }
            #endregion

            #region Student-Course
            if (!context.StudentCourses.Any())
            {
                // Usado para acessar o indice
                var allStudents = context.Students.ToArray(); 
                var studentCourses = new StudentCourse[]
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

                context.StudentCourses.AddRange(studentCourses);
                context.SaveChanges();
            }
            #endregion

            #region Course-Modules
            if (!context.CourseModules.Any())
            {
                var courseModules = new CourseModule[]
                {
                    // Ciencia da computacao
                    new() { CourseID = 1, ModuleID = 1, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 1, ModuleID = 2, Semester = 2, DayOfWeek = DayOfWeek.Tuesday },
                    new() { CourseID = 1, ModuleID = 3, Semester = 2, DayOfWeek = DayOfWeek.Wednesday },
                    new() { CourseID = 1, ModuleID = 7, Semester = 1, DayOfWeek = DayOfWeek.Thursday }, 

                    // Matematica
                    new() { CourseID = 2, ModuleID = 5, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 2, ModuleID = 6, Semester = 2, DayOfWeek = DayOfWeek.Tuesday },
                    new() { CourseID = 2, ModuleID = 7, Semester = 1, DayOfWeek = DayOfWeek.Wednesday },

                    // Fisica
                    new() { CourseID = 3, ModuleID = 8, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 3, ModuleID = 9, Semester = 2, DayOfWeek = DayOfWeek.Tuesday },

                    // Quimica
                    new() { CourseID = 4, ModuleID = 10, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 4, ModuleID = 11, Semester = 2, DayOfWeek = DayOfWeek.Tuesday },

                    // Biologia
                    new() { CourseID = 5, ModuleID = 12, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 5, ModuleID = 13, Semester = 2, DayOfWeek = DayOfWeek.Tuesday },

                    // Literatura Inglesa
                    new() { CourseID = 6, ModuleID = 14, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 6, ModuleID = 15, Semester = 2, DayOfWeek = DayOfWeek.Tuesday },

                    // Historia
                    new() { CourseID = 7, ModuleID = 16, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 7, ModuleID = 17, Semester = 2, DayOfWeek = DayOfWeek.Tuesday },

                    // Filosofia
                    new() { CourseID = 8, ModuleID = 18, Semester = 1, DayOfWeek = DayOfWeek.Monday },
                    new() { CourseID = 8, ModuleID = 19, Semester = 2, DayOfWeek = DayOfWeek.Tuesday }
                };

                context.CourseModules.AddRange(courseModules);
                context.SaveChanges();
            }
            #endregion
        }
    }
}
