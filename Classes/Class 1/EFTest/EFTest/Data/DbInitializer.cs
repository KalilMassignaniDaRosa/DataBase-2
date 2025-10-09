using EFTest.Models.Courses;
using EFTest.Models.Students;
using EFTest.Models.Modules;

namespace EFTest.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();
            // Tem materias que nao estao colocadas correamente nos cursos
            // Apenas para exemplo

            #region Student
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
                new() {FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")},
                new() {FirstMidName="John",LastName="Smith",EnrollmentDate=DateTime.Parse("2004-09-01")},
                new() {FirstMidName="Maria",LastName="Garcia",EnrollmentDate=DateTime.Parse("2003-09-01")},
                new() {FirstMidName="David",LastName="Johnson",EnrollmentDate=DateTime.Parse("2002-09-01")},
                new() {FirstMidName="Sarah",LastName="Williams",EnrollmentDate=DateTime.Parse("2001-09-01")}
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
                    new() { Name = "Philosophy", CreationDate = DateTime.Parse("2024-07-05"), NumberOfSemesters = 4 },
                    new() { Name = "Engineering", CreationDate = DateTime.Parse("2024-08-01"), NumberOfSemesters = 10 },
                    new() { Name = "Medicine", CreationDate = DateTime.Parse("2024-09-01"), NumberOfSemesters = 12 },
                    new() { Name = "Business Administration", CreationDate = DateTime.Parse("2024-10-01"), NumberOfSemesters = 8 },
                    new() { Name = "Psychology", CreationDate = DateTime.Parse("2024-11-01"), NumberOfSemesters = 8 }
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
                    new() { Name = "Introduction to Programming", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-01") },
                    new() { Name = "Data Structures", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-01-02") },
                    new() { Name = "Algorithms", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-01-03") },
                    new() { Name = "Computer Architecture", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-04") },
                    new() { Name = "Database Systems", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-01-05") },
                    new() { Name = "Operating Systems", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-01-06") },
                    new() { Name = "Software Engineering", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-07") },
                    new() { Name = "Computer Networks", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-08") },
                    new() { Name = "Web Development", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-01-09") },
                    new() { Name = "Mobile Development", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-01-10") },
                    new() { Name = "Artificial Intelligence", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-01-11") },
                    new() { Name = "Machine Learning", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-01-12") },
                    new() { Name = "Cybersecurity", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-13") },
                    new() { Name = "Cloud Computing", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-01-14") },
                    new() { Name = "Big Data", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-01-15") },

                    new() { Name = "Calculus I", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-01") },
                    new() { Name = "Calculus II", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-02") },
                    new() { Name = "Linear Algebra", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-03") },
                    new() { Name = "Discrete Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-04") },
                    new() { Name = "Probability", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-05") },
                    new() { Name = "Statistics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-06") },
                    new() { Name = "Differential Equations", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-07") },
                    new() { Name = "Numerical Methods", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-08") },
                    new() { Name = "Complex Analysis", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-09") },
                    new() { Name = "Abstract Algebra", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-02-10") },

                    new() { Name = "Classical Mechanics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-01") },
                    new() { Name = "Electromagnetism", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-02") },
                    new() { Name = "Thermodynamics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-03") },
                    new() { Name = "Quantum Mechanics", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-03-04") },
                    new() { Name = "Relativity", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-05") },
                    new() { Name = "Optics", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-03-06") },
                    new() { Name = "Nuclear Physics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-07") },
                    new() { Name = "Particle Physics", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-03-08") },
                    new() { Name = "Astrophysics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-09") },
                    new() { Name = "Solid State Physics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-10") },

                    new() { Name = "Organic Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-25") },
                    new() { Name = "Inorganic Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-26") },
                    new() { Name = "Physical Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-27") },
                    new() { Name = "Analytical Chemistry", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-03-28") },
                    new() { Name = "Biochemistry", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-03-29") },
                    new() { Name = "Environmental Chemistry", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-03-30") },
                    new() { Name = "Polymer Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-03-31") },
                    new() { Name = "Medicinal Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-04-01") },
                    new() { Name = "Computational Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-04-02") },
                    new() { Name = "Quantum Chemistry", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-04-03") },

                    new() { Name = "Cell Biology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-01") },
                    new() { Name = "Genetics", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-02") },
                    new() { Name = "Microbiology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-03") },
                    new() { Name = "Biochemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-04-04") },
                    new() { Name = "Molecular Biology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-04-05") },
                    new() { Name = "Ecology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-06") },
                    new() { Name = "Evolutionary Biology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-07") },
                    new() { Name = "Physiology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-04-08") },
                    new() { Name = "Immunology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-04-09") },
                    new() { Name = "Neuroscience", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-04-10") },

                    new() { Name = "Shakespearean Literature", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-01") },
                    new() { Name = "Modern Poetry", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-02") },
                    new() { Name = "American Literature", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-03") },
                    new() { Name = "British Literature", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-04") },
                    new() { Name = "Literary Theory", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-05") },
                    new() { Name = "Creative Writing", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-06") },
                    new() { Name = "Drama Studies", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-07") },
                    new() { Name = "Postcolonial Literature", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-08") },
                    new() { Name = "Children's Literature", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-09") },
                    new() { Name = "Science Fiction", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-05-10") },

                    new() { Name = "World History I", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-01") },
                    new() { Name = "World History II", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-02") },
                    new() { Name = "European History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-03") },
                    new() { Name = "American History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-04") },
                    new() { Name = "Ancient History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-05") },
                    new() { Name = "Medieval History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-06") },
                    new() { Name = "Modern History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-07") },
                    new() { Name = "Military History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-08") },
                    new() { Name = "Cultural History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-09") },
                    new() { Name = "Economic History", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-06-10") },

                    new() { Name = "Ethics", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-01") },
                    new() { Name = "Logic", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-02") },
                    new() { Name = "Metaphysics", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-03") },
                    new() { Name = "Epistemology", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-04") },
                    new() { Name = "Political Philosophy", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-05") },
                    new() { Name = "Aesthetics", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-06") },
                    new() { Name = "Existentialism", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-07") },
                    new() { Name = "Philosophy of Science", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-08") },
                    new() { Name = "Philosophy of Mind", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-09") },
                    new() { Name = "Ancient Philosophy", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-07-10") },

                    new() { Name = "Engineering Mathematics", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-08-01") },
                    new() { Name = "Mechanics", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-08-02") },
                    new() { Name = "Thermodynamics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-08-03") },
                    new() { Name = "Materials Science", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-08-04") },
                    new() { Name = "Electrical Circuits", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-08-05") },
                    new() { Name = "Digital Systems", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-08-06") },
                    new() { Name = "Fluid Mechanics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-08-07") },
                    new() { Name = "Structural Analysis", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-08-08") },
                    new() { Name = "Control Systems", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-08-09") },
                    new() { Name = "Engineering Design", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-08-10") },
                    new() { Name = "Heat Transfer", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-08-11") },
                    new() { Name = "Manufacturing Processes", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-08-12") },
                    new() { Name = "Engineering Economics", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-08-13") },
                    new() { Name = "Project Management", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-08-14") },
                    new() { Name = "Sustainable Engineering", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-08-15") },

                    new() { Name = "Human Anatomy", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-09-01") },
                    new() { Name = "Physiology", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-09-02") },
                    new() { Name = "Biochemistry", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-09-03") },
                    new() { Name = "Pharmacology", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-09-04") },
                    new() { Name = "Pathology", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-09-05") },
                    new() { Name = "Microbiology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-09-06") },
                    new() { Name = "Immunology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-09-07") },
                    new() { Name = "Neuroscience", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-09-08") },
                    new() { Name = "Cardiology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-09-09") },
                    new() { Name = "Pediatrics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-09-10") },
                    new() { Name = "Surgery", WorkloadHours = 80, CreationDate = DateTime.Parse("2024-09-11") },
                    new() { Name = "Internal Medicine", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-09-12") },
                    new() { Name = "Psychiatry", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-09-13") },
                    new() { Name = "Radiology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-09-14") },
                    new() { Name = "Public Health", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-09-15") },

                    new() { Name = "Principles of Management", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-10-01") },
                    new() { Name = "Accounting", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-10-02") },
                    new() { Name = "Marketing", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-10-03") },
                    new() { Name = "Finance", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-10-04") },
                    new() { Name = "Human Resources", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-10-05") },
                    new() { Name = "Operations Management", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-10-06") },
                    new() { Name = "Business Law", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-10-07") },
                    new() { Name = "Strategic Management", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-10-08") },
                    new() { Name = "International Business", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-10-09") },
                    new() { Name = "Entrepreneurship", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-10-10") },
                    new() { Name = "Organizational Behavior", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-10-11") },
                    new() { Name = "Business Ethics", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-10-12") },
                    new() { Name = "Supply Chain Management", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-10-13") },
                    new() { Name = "Business Analytics", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-10-14") },
                    new() { Name = "E-Commerce", WorkloadHours = 40, CreationDate = DateTime.Parse("2024-10-15") },

                    new() { Name = "Introduction to Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-01") },
                    new() { Name = "Developmental Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-02") },
                    new() { Name = "Cognitive Psychology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-11-03") },
                    new() { Name = "Social Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-04") },
                    new() { Name = "Abnormal Psychology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-11-05") },
                    new() { Name = "Clinical Psychology", WorkloadHours = 70, CreationDate = DateTime.Parse("2024-11-06") },
                    new() { Name = "Research Methods", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-11-07") },
                    new() { Name = "Biological Psychology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-11-08") },
                    new() { Name = "Personality Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-09") },
                    new() { Name = "Forensic Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-10") },
                    new() { Name = "Health Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-11") },
                    new() { Name = "Educational Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-12") },
                    new() { Name = "Industrial Psychology", WorkloadHours = 50, CreationDate = DateTime.Parse("2024-11-13") },
                    new() { Name = "Neuropsychology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-11-14") },
                    new() { Name = "Counseling Psychology", WorkloadHours = 60, CreationDate = DateTime.Parse("2024-11-15") }
                };

                context.Modules.AddRange(modules);
                context.SaveChanges();
            }
            #endregion

            #region CourseModules
            if (!context.CourseModules.Any())
            {
                var courseModules = new List<CourseModule>();
                var dayOfWeeks = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

                // Pega todos os módulos criados para verificar se existem
                var allModules = context.Modules.Select(m => m.ID).ToList();

                // Ciencia da computacao, 8 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 8; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = (semester - 1) * 5 + i + 1;
                        if (moduleId <= 40 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 1,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Matematica, 6 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 6; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 40 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 70 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 2,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Fisica, 6 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 6; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 70 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 100 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 3,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Quimica, 6 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 6; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 100 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 130 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 4,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Biologia, 6 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 6; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 130 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 160 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 5,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Literatura, 4 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 4; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 160 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 180 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 6,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Historia, 4 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 4; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 180 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 200 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 7,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Filosofia, 4 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 4; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 200 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 220 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 8,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Engenharia, 10 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 10; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 220 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 270 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 9,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Medicina, 12 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 12; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 270 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 330 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 10,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Administracao, 8 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 8; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 330 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 370 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 11,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                // Psicologia, 8 semestre, 5 materias por semestre
                for (int semester = 1; semester <= 8; semester++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int moduleId = 370 + (semester - 1) * 5 + i + 1;
                        if (moduleId <= 410 && allModules.Contains(moduleId))
                        {
                            courseModules.Add(new CourseModule
                            {
                                CourseID = 12,
                                ModuleID = moduleId,
                                Semester = semester,
                                DayOfWeek = dayOfWeeks[i % 5]
                            });
                        }
                    }
                }

                context.CourseModules.AddRange(courseModules);
                context.SaveChanges();
            }
            #endregion

            #region Module Prerequisites
            if (!context.ModulePrerequisites.Any())
            {
                var prerequisites = new List<ModulePrerequisite>();
                var allModules = context.Modules.Select(m => m.ID).ToList();

                // Ciencia da Computacao
                for (int i = 2; i <= 40; i++)
                {
                    if (i % 5 != 1 && allModules.Contains(i) && allModules.Contains(i - 1))
                    {
                        prerequisites.Add(new ModulePrerequisite { ModuleID = i, PrerequisiteID = i - 1 });
                    }
                }

                // Matematica
                for (int i = 42; i <= 70; i++)
                {
                    if (i % 5 != 1 && allModules.Contains(i) && allModules.Contains(i - 1))
                    {
                        prerequisites.Add(new ModulePrerequisite { ModuleID = i, PrerequisiteID = i - 1 });
                    }
                }

                // Fisica
                for (int i = 72; i <= 100; i++)
                {
                    if (i % 5 != 1 && allModules.Contains(i) && allModules.Contains(i - 1))
                    {
                        prerequisites.Add(new ModulePrerequisite { ModuleID = i, PrerequisiteID = i - 1 });
                    }
                }

                // Quimica
                for (int i = 102; i <= 130; i++)
                {
                    if (i % 5 != 1 && allModules.Contains(i) && allModules.Contains(i - 1))
                    {
                        prerequisites.Add(new ModulePrerequisite { ModuleID = i, PrerequisiteID = i - 1 });
                    }
                }

                // Biologia
                for (int i = 132; i <= 160; i++)
                {
                    if (i % 5 != 1 && allModules.Contains(i) && allModules.Contains(i - 1))
                    {
                        prerequisites.Add(new ModulePrerequisite { ModuleID = i, PrerequisiteID = i - 1 });
                    }
                }

                // Prerequisitos de outras
                if (allModules.Contains(41) && allModules.Contains(20))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 41, PrerequisiteID = 20 });

                if (allModules.Contains(71) && allModules.Contains(15))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 71, PrerequisiteID = 15 });

                if (allModules.Contains(101) && allModules.Contains(35))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 101, PrerequisiteID = 35 });

                if (allModules.Contains(131) && allModules.Contains(55))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 131, PrerequisiteID = 55 });

                if (allModules.Contains(221) && allModules.Contains(5))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 221, PrerequisiteID = 5 });

                if (allModules.Contains(271) && allModules.Contains(135))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 271, PrerequisiteID = 135 });

                if (allModules.Contains(331) && allModules.Contains(165))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 331, PrerequisiteID = 165 });

                if (allModules.Contains(371) && allModules.Contains(205))
                    prerequisites.Add(new ModulePrerequisite { ModuleID = 371, PrerequisiteID = 205 });

                context.ModulePrerequisites.AddRange(prerequisites);
                context.SaveChanges();
            }
            #endregion

            #region StudentCourse
            if (!context.StudentCourses.Any())
            {
                var studentCourses = new StudentCourse[]
                {
                    new() { StudentID = 1, CourseID = 1, SignDate = DateTime.Parse("2024-08-01") },
                    new() { StudentID = 1, CourseID = 2, SignDate = DateTime.Parse("2024-08-03") },
                    new() { StudentID = 2, CourseID = 1, SignDate = DateTime.Parse("2024-08-04") },
                    new() { StudentID = 3, CourseID = 3, SignDate = DateTime.Parse("2024-08-06") },
                    new() { StudentID = 4, CourseID = 4, SignDate = DateTime.Parse("2024-08-08") },
                    new() { StudentID = 5, CourseID = 5, SignDate = DateTime.Parse("2024-08-10") },
                    new() { StudentID = 6, CourseID = 6, SignDate = DateTime.Parse("2024-08-12") },
                    new() { StudentID = 7, CourseID = 7, SignDate = DateTime.Parse("2024-08-14") },
                    new() { StudentID = 8, CourseID = 8, SignDate = DateTime.Parse("2024-08-16") },
                    new() { StudentID = 9, CourseID = 9, SignDate = DateTime.Parse("2024-08-18") },
                    new() { StudentID = 10, CourseID = 10, SignDate = DateTime.Parse("2024-08-20") },
                    new() { StudentID = 11, CourseID = 11, SignDate = DateTime.Parse("2024-08-22") },
                    new() { StudentID = 12, CourseID = 12, SignDate = DateTime.Parse("2024-08-24") },
                    new() { StudentID = 2, CourseID = 3, SignDate = DateTime.Parse("2024-08-26") },
                    new() { StudentID = 3, CourseID = 4, SignDate = DateTime.Parse("2024-08-28") },
                    new() { StudentID = 4, CourseID = 5, SignDate = DateTime.Parse("2024-08-30") },
                    new() { StudentID = 5, CourseID = 6, SignDate = DateTime.Parse("2024-09-01") },
                    new() { StudentID = 6, CourseID = 7, SignDate = DateTime.Parse("2024-09-03") },
                    new() { StudentID = 7, CourseID = 8, SignDate = DateTime.Parse("2024-09-05") },
                    new() { StudentID = 8, CourseID = 9, SignDate = DateTime.Parse("2024-09-07") }
                };

                context.StudentCourses.AddRange(studentCourses);
                context.SaveChanges();
            }
            #endregion

            #region StudentModules
            if (!context.StudentModules.Any())
            {
                var studentModules = new List<StudentModule>();
                var allModules = context.Modules.Select(m => m.ID).ToList();
                var allStudents = context.Students.ToArray();

                // Cria StudentModules apenas para materias que existem
                var studentModuleData = new[]
                {
                    new { StudentID = 1, ModuleID = 1, CourseID = 1, Grade = 8.5, Frequency = 90, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 1, ModuleID = 2, CourseID = 1, Grade = 7.0, Frequency = 85, Status = ModuleStatusEnum.Enrolled },
                    new { StudentID = 2, ModuleID = 1, CourseID = 1, Grade = 5.0, Frequency = 60, Status = ModuleStatusEnum.Failed },
                    new { StudentID = 3, ModuleID = 71, CourseID = 3, Grade = 9.0, Frequency = 95, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 4, ModuleID = 101, CourseID = 4, Grade = 8.0, Frequency = 88, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 5, ModuleID = 131, CourseID = 5, Grade = 7.5, Frequency = 82, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 6, ModuleID = 161, CourseID = 6, Grade = 6.5, Frequency = 75, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 7, ModuleID = 181, CourseID = 7, Grade = 8.0, Frequency = 90, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 8, ModuleID = 201, CourseID = 8, Grade = 7.8, Frequency = 85, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 9, ModuleID = 221, CourseID = 9, Grade = 6.0, Frequency = 70, Status = ModuleStatusEnum.Enrolled },
                    new { StudentID = 10, ModuleID = 271, CourseID = 10, Grade = 9.2, Frequency = 96, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 11, ModuleID = 331, CourseID = 11, Grade = 8.7, Frequency = 92, Status = ModuleStatusEnum.Approved },
                    new { StudentID = 12, ModuleID = 371, CourseID = 12, Grade = 7.3, Frequency = 80, Status = ModuleStatusEnum.Enrolled }
                };

                foreach (var data in studentModuleData)
                {
                    // Verifica se a materia existe
                    if (allModules.Contains(data.ModuleID))
                    {
                        studentModules.Add(new StudentModule
                        {
                            StudentID = data.StudentID,
                            ModuleID = data.ModuleID,
                            CourseID = data.CourseID,
                            Grade = data.Grade,
                            Frequency = data.Frequency,
                            Status = data.Status,
                            SignDate = DateTime.Now.AddMonths(-2)
                        });
                    }
                }

                context.StudentModules.AddRange(studentModules);
                context.SaveChanges();
            }
            #endregion
        }
    }
}