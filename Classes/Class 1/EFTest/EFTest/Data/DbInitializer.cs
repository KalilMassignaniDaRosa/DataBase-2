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
            // Tem materias que nao estao colocadas corretamente nos cursos
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
                    new() { Name = "Computer Science", CreationDate = DateTime.Parse("2020-01-10"), NumberOfSemesters = 8 },
                    new() { Name = "Computer Engineering", CreationDate = DateTime.Parse("2019-02-15"), NumberOfSemesters = 10 },
                    new() { Name = "Agronomy", CreationDate = DateTime.Parse("2018-03-20"), NumberOfSemesters = 8 },
                    new() { Name = "Mathematics (Teaching Degree)", CreationDate = DateTime.Parse("2017-04-25"), NumberOfSemesters = 8 },
                    new() { Name = "Medicine", CreationDate = DateTime.Parse("2016-05-30"), NumberOfSemesters = 12 }

                };

                context.Courses.AddRange(courses);
                context.SaveChanges();
            }
            #endregion

            #region Modules
            if (!context.Modules.Any())
            {
                var modules = new List<Module>();

                #region Computer Science
                var computerScienceModules = new Module[]
                {
                    // Semestre 1
                    new() { Name = "Introduction to Computing", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-01-01") },
                    new() { Name = "Algorithm and Programming Logic", WorkloadHours = 80, CreationDate = DateTime.Parse("2020-01-02") },
                    new() { Name = "Calculus I", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-01-03") },
                    new() { Name = "Discrete Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-01-04") },
                    new() { Name = "Digital Systems", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-01-05") },
                    new() { Name = "Technical Communication", WorkloadHours = 40, CreationDate = DateTime.Parse("2020-01-06") },

                    // Semestre 2
                    new() { Name = "Object-Oriented Programming", WorkloadHours = 80, CreationDate = DateTime.Parse("2020-02-01") },
                    new() { Name = "Data Structures", WorkloadHours = 80, CreationDate = DateTime.Parse("2020-02-02") },
                    new() { Name = "Calculus II", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-02-03") },
                    new() { Name = "Computer Architecture", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-02-04") },
                    new() { Name = "Linear Algebra", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-02-05") },

                    // Semestre 3
                    new() { Name = "Algorithms and Complexity", WorkloadHours = 80, CreationDate = DateTime.Parse("2020-03-01") },
                    new() { Name = "Database Systems I", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-03-02") },
                    new() { Name = "Operating Systems", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-03-03") },
                    new() { Name = "Probability and Statistics", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-03-04") },
                    new() { Name = "Software Engineering I", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-03-05") },

                    // Semestre 4
                    new() { Name = "Database Systems II", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-04-01") },
                    new() { Name = "Computer Networks", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-04-02") },
                    new() { Name = "Web Development", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-04-03") },
                    new() { Name = "Software Engineering II", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-04-04") },
                    new() { Name = "Human-Computer Interaction", WorkloadHours = 40, CreationDate = DateTime.Parse("2020-04-05") },

                    // Semestre 5
                    new() { Name = "Artificial Intelligence", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-05-01") },
                    new() { Name = "Compilers", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-05-02") },
                    new() { Name = "Distributed Systems", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-05-03") },
                    new() { Name = "Computer Graphics", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-05-04") },
                    new() { Name = "Formal Languages and Automata", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-05-05") },

                    // Semestre 6
                    new() { Name = "Machine Learning", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-06-01") },
                    new() { Name = "Mobile Development", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-06-02") },
                    new() { Name = "Information Security", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-06-03") },
                    new() { Name = "Software Testing and Quality", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-06-04") },
                    new() { Name = "Cloud Computing", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-06-05") },

                    // Semestre 7
                    new() { Name = "Software Project Management", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-07-01") },
                    new() { Name = "Entrepreneurship in Computing", WorkloadHours = 40, CreationDate = DateTime.Parse("2020-07-02") },
                    new() { Name = "Professional Ethics", WorkloadHours = 40, CreationDate = DateTime.Parse("2020-07-03") },
                    new() { Name = "Internship I", WorkloadHours = 100, CreationDate = DateTime.Parse("2020-07-04") },
                    new() { Name = "Final Project I", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-07-05") },

                    // Semestre 8
                    new() { Name = "Advanced Topics in Computing", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-08-01") },
                    new() { Name = "Internship II", WorkloadHours = 100, CreationDate = DateTime.Parse("2020-08-02") },
                    new() { Name = "Final Project II", WorkloadHours = 60, CreationDate = DateTime.Parse("2020-08-03") },
                    new() { Name = "Career Planning", WorkloadHours = 40, CreationDate = DateTime.Parse("2020-08-04") }
                };

                modules.AddRange(computerScienceModules);
                #endregion

                #region Computer Engineering
                var computerEngineeringModules = new Module[]
                {
                    // Semestre 1
                    new() { Name = "Engineering Calculus I", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-01-01") },
                    new() { Name = "General Physics I", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-01-02") },
                    new() { Name = "Technical Drawing", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-01-03") },
                    new() { Name = "Introduction to Engineering", WorkloadHours = 40, CreationDate = DateTime.Parse("2019-01-04") },
                    new() { Name = "Chemistry for Engineering", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-01-05") },

                    // Semestre 2
                    new() { Name = "Engineering Calculus II", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-02-01") },
                    new() { Name = "General Physics II", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-02-02") },
                    new() { Name = "Algorithm and Programming Logic", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-02-03") },
                    new() { Name = "Linear Algebra", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-02-04") },
                    new() { Name = "Experimental Physics", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-02-05") },

                    // Semestre 3
                    new() { Name = "Electrical Circuits I", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-03-01") },
                    new() { Name = "Digital Systems", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-03-02") },
                    new() { Name = "Object-Oriented Programming", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-03-03") },
                    new() { Name = "Differential Equations", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-03-04") },
                    new() { Name = "Numerical Calculus", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-03-05") },

                    // Semestre 4
                    new() { Name = "Electrical Circuits II", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-04-01") },
                    new() { Name = "Electronics I", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-04-02") },
                    new() { Name = "Microprocessors", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-04-03") },
                    new() { Name = "Data Structures", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-04-04") },
                    new() { Name = "Probability and Statistics", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-04-05") },

                    // Semestre 5
                    new() { Name = "Electronics II", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-05-01") },
                    new() { Name = "Computer Architecture", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-05-02") },
                    new() { Name = "Signals and Systems", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-05-03") },
                    new() { Name = "Algorithms and Complexity", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-05-04") },
                    new() { Name = "Database Systems", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-05-05") },

                    // Semestre 6
                    new() { Name = "Embedded Systems", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-06-01") },
                    new() { Name = "Control Systems", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-06-02") },
                    new() { Name = "Operating Systems", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-06-03") },
                    new() { Name = "Computer Networks", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-06-04") },
                    new() { Name = "Software Engineering", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-06-05") },

                    // Semestre 7
                    new() { Name = "Digital Signal Processing", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-07-01") },
                    new() { Name = "VLSI Design", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-07-02") },
                    new() { Name = "Real-Time Systems", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-07-03") },
                    new() { Name = "Computer Networks II", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-07-04") },
                    new() { Name = "Engineering Economics", WorkloadHours = 40, CreationDate = DateTime.Parse("2019-07-05") },

                    // Semestre 8
                    new() { Name = "Industrial Automation", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-08-01") },
                    new() { Name = "Robotics", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-08-02") },
                    new() { Name = "Digital Control Systems", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-08-03") },
                    new() { Name = "Instrumentation", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-08-04") },
                    new() { Name = "Engineering Project I", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-08-05") },

                    // Semestre 9
                    new() { Name = "Artificial Intelligence", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-09-01") },
                    new() { Name = "Computer Vision", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-09-02") },
                    new() { Name = "Internet of Things", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-09-03") },
                    new() { Name = "Embedded Software", WorkloadHours = 80, CreationDate = DateTime.Parse("2019-09-04") },
                    new() { Name = "Engineering Project II", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-09-05") },

                    // Semestre 10
                    new() { Name = "Professional Practice", WorkloadHours = 100, CreationDate = DateTime.Parse("2019-10-01") },
                    new() { Name = "Final Engineering Project", WorkloadHours = 100, CreationDate = DateTime.Parse("2019-10-02") },
                    new() { Name = "Engineering Management", WorkloadHours = 60, CreationDate = DateTime.Parse("2019-10-03") },
                    new() { Name = "Technical Entrepreneurship", WorkloadHours = 40, CreationDate = DateTime.Parse("2019-10-04") }
                };

                modules.AddRange(computerEngineeringModules);
                #endregion

                #region Agronomy 
                var agronomyModules = new Module[]
                {
                    // Semestre 1
                    new() { Name = "Introduction to Agronomy", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-01-01") },
                    new() { Name = "General Botany", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-01-02") },
                    new() { Name = "General Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-01-03") },
                    new() { Name = "Mathematics for Agronomy", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-01-04") },
                    new() { Name = "Technical Drawing", WorkloadHours = 40, CreationDate = DateTime.Parse("2018-01-05") },

                    // Semestre 2
                    new() { Name = "Plant Physiology", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-02-01") },
                    new() { Name = "Organic Chemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-02-02") },
                    new() { Name = "Soil Science", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-02-03") },
                    new() { Name = "Biochemistry", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-02-04") },
                    new() { Name = "Statistics", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-02-05") },

                    // Semestre 3
                    new() { Name = "Plant Morphology", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-03-01") },
                    new() { Name = "Soil Fertility", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-03-02") },
                    new() { Name = "Agricultural Microbiology", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-03-03") },
                    new() { Name = "Agricultural Climatology", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-03-04") },
                    new() { Name = "Agricultural Entomology", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-03-05") },

                    // Semestre 4
                    new() { Name = "Plant Nutrition", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-04-01") },
                    new() { Name = "Phytopathology", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-04-02") },
                    new() { Name = "Forage Crops", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-04-03") },
                    new() { Name = "Cereal Crops", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-04-04") },
                    new() { Name = "Weed Science", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-04-05") },

                    // Semestre 5
                    new() { Name = "Agricultural Machinery", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-05-01") },
                    new() { Name = "Irrigation and Drainage", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-05-02") },
                    new() { Name = "Soil Conservation", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-05-03") },
                    new() { Name = "Agricultural Genetics", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-05-04") },
                    new() { Name = "Plant Breeding", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-05-05") },

                    // Semestre 6
                    new() { Name = "Fruit Culture", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-06-01") },
                    new() { Name = "Vegetable Crops", WorkloadHours = 80, CreationDate = DateTime.Parse("2018-06-02") },
                    new() { Name = "Agricultural Pesticides", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-06-03") },
                    new() { Name = "Organic Agriculture", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-06-04") },
                    new() { Name = "Agricultural Zootechnics", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-06-05") },

                    // Semestre 7
                    new() { Name = "Agricultural Management", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-07-01") },
                    new() { Name = "Rural Economics", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-07-02") },
                    new() { Name = "Agricultural Marketing", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-07-03") },
                    new() { Name = "Rural Extension", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-07-04") },
                    new() { Name = "Agricultural Project I", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-07-05") },

                    // Semestre 8
                    new() { Name = "Agricultural Legislation", WorkloadHours = 40, CreationDate = DateTime.Parse("2018-08-01") },
                    new() { Name = "Environmental Management", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-08-02") },
                    new() { Name = "Precision Agriculture", WorkloadHours = 60, CreationDate = DateTime.Parse("2018-08-03") },
                    new() { Name = "Agricultural Project II", WorkloadHours = 100, CreationDate = DateTime.Parse("2018-08-04") },
                    new() { Name = "Professional Internship", WorkloadHours = 100, CreationDate = DateTime.Parse("2018-08-05") }
                };

                modules.AddRange(agronomyModules);
                #endregion

                #region Mathematics
                var mathematicsModules = new Module[]
                {
                    // Semestre 1
                    new() { Name = "Differential and Integral Calculus I", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-01-01") },
                    new() { Name = "Vector Geometry and Linear Algebra", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-01-02") },
                    new() { Name = "Mathematical Logic", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-01-03") },
                    new() { Name = "Introduction to Higher Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-01-04") },
                    new() { Name = "Portuguese Language", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-01-05") },

                    // Semestre 2
                    new() { Name = "Differential and Integral Calculus II", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-02-01") },
                    new() { Name = "Analytic Geometry", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-02-02") },
                    new() { Name = "Theory of Sets", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-02-03") },
                    new() { Name = "Computer Science for Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-02-04") },
                    new() { Name = "Philosophy of Education", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-02-05") },

                    // Semestre 3
                    new() { Name = "Differential and Integral Calculus III", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-03-01") },
                    new() { Name = "Abstract Algebra I", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-03-02") },
                    new() { Name = "Numerical Calculus", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-03-03") },
                    new() { Name = "Probability and Statistics I", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-03-04") },
                    new() { Name = "Educational Psychology", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-03-05") },

                    // Semestre 4
                    new() { Name = "Differential Equations", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-04-01") },
                    new() { Name = "Abstract Algebra II", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-04-02") },
                    new() { Name = "Real Analysis I", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-04-03") },
                    new() { Name = "Probability and Statistics II", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-04-04") },
                    new() { Name = "History of Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-04-05") },

                    // Semestre 5
                    new() { Name = "Complex Analysis", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-05-01") },
                    new() { Name = "Linear Algebra", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-05-02") },
                    new() { Name = "Real Analysis II", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-05-03") },
                    new() { Name = "Mathematical Modeling", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-05-04") },
                    new() { Name = "Teaching Methodology I", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-05-05") },

                    // Semestre 6
                    new() { Name = "Topology", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-06-01") },
                    new() { Name = "Number Theory", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-06-02") },
                    new() { Name = "Geometry", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-06-03") },
                    new() { Name = "Teaching Methodology II", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-06-04") },
                    new() { Name = "Educational Technology", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-06-05") },

                    // Semestre 7
                    new() { Name = "Functional Analysis", WorkloadHours = 80, CreationDate = DateTime.Parse("2017-07-01") },
                    new() { Name = "Discrete Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-07-02") },
                    new() { Name = "Mathematics Teaching Internship I", WorkloadHours = 100, CreationDate = DateTime.Parse("2017-07-03") },
                    new() { Name = "Scientific Research Methodology", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-07-04") },
                    new() { Name = "Educational Assessment", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-07-05") },

                    // Semestre 8
                    new() { Name = "Mathematics Teaching Internship II", WorkloadHours = 100, CreationDate = DateTime.Parse("2017-08-01") },
                    new() { Name = "Final Course Project", WorkloadHours = 100, CreationDate = DateTime.Parse("2017-08-02") },
                    new() { Name = "Special Topics in Mathematics", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-08-03") },
                    new() { Name = "School Management", WorkloadHours = 60, CreationDate = DateTime.Parse("2017-08-04") },
                    new() { Name = "Educational Legislation", WorkloadHours = 40, CreationDate = DateTime.Parse("2017-08-05") }
                };

                modules.AddRange(mathematicsModules);
                #endregion

                #region Medicine 
                var medicineModules = new Module[]
                {
                    // Semestre 1
                    new() { Name = "Human Anatomy I", WorkloadHours = 120, CreationDate = DateTime.Parse("2016-01-01") },
                    new() { Name = "Medical Histology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-01-02") },
                    new() { Name = "Medical Embryology", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-01-03") },
                    new() { Name = "Biochemistry I", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-01-04") },
                    new() { Name = "Introduction to Medicine", WorkloadHours = 40, CreationDate = DateTime.Parse("2016-01-05") },

                    // Semestre 2
                    new() { Name = "Human Anatomy II", WorkloadHours = 120, CreationDate = DateTime.Parse("2016-02-01") },
                    new() { Name = "Medical Physiology I", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-02-02") },
                    new() { Name = "Medical Genetics", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-02-03") },
                    new() { Name = "Biochemistry II", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-02-04") },
                    new() { Name = "Medical Psychology", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-02-05") },

                    // Semestre 3
                    new() { Name = "Medical Physiology II", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-03-01") },
                    new() { Name = "Medical Biophysics", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-03-02") },
                    new() { Name = "Medical Immunology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-03-03") },
                    new() { Name = "Medical Parasitology", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-03-04") },
                    new() { Name = "Medical Ethics I", WorkloadHours = 40, CreationDate = DateTime.Parse("2016-03-05") },

                    // Semestre 4
                    new() { Name = "General Pathology", WorkloadHours = 100, CreationDate = DateTime.Parse("2016-04-01") },
                    new() { Name = "Medical Microbiology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-04-02") },
                    new() { Name = "Pharmacology I", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-04-03") },
                    new() { Name = "Medical Semiology I", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-04-04") },
                    new() { Name = "Epidemiology", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-04-05") },

                    // Semestre 5
                    new() { Name = "Internal Medicine I", WorkloadHours = 100, CreationDate = DateTime.Parse("2016-05-01") },
                    new() { Name = "Surgical Technique", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-05-02") },
                    new() { Name = "Pharmacology II", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-05-03") },
                    new() { Name = "Medical Semiology II", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-05-04") },
                    new() { Name = "Medical Propaedeutics", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-05-05") },

                    // Semestre 6
                    new() { Name = "Internal Medicine II", WorkloadHours = 100, CreationDate = DateTime.Parse("2016-06-01") },
                    new() { Name = "General Surgery", WorkloadHours = 100, CreationDate = DateTime.Parse("2016-06-02") },
                    new() { Name = "Pediatrics I", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-06-03") },
                    new() { Name = "Obstetrics I", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-06-04") },
                    new() { Name = "Medical Ethics II", WorkloadHours = 40, CreationDate = DateTime.Parse("2016-06-05") },

                    // Semestre 7
                    new() { Name = "Cardiology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-07-01") },
                    new() { Name = "Pulmonology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-07-02") },
                    new() { Name = "Gastroenterology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-07-03") },
                    new() { Name = "Nephrology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-07-04") },
                    new() { Name = "Endocrinology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-07-05") },

                    // Semestre 8
                    new() { Name = "Neurology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-08-01") },
                    new() { Name = "Psychiatry", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-08-02") },
                    new() { Name = "Dermatology", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-08-03") },
                    new() { Name = "Ophthalmology", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-08-04") },
                    new() { Name = "Otorhinolaryngology", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-08-05") },

                    // Semestre 9
                    new() { Name = "Orthopedics", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-09-01") },
                    new() { Name = "Urology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-09-02") },
                    new() { Name = "Anesthesiology", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-09-03") },
                    new() { Name = "Pediatrics II", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-09-04") },
                    new() { Name = "Obstetrics II", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-09-05") },

                    // Semestre 10
                    new() { Name = "Preventive Medicine", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-10-01") },
                    new() { Name = "Family and Community Medicine", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-10-02") },
                    new() { Name = "Public Health", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-10-03") },
                    new() { Name = "Medical Law", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-10-04") },
                    new() { Name = "Medical Internship I", WorkloadHours = 120, CreationDate = DateTime.Parse("2016-10-05") },

                    // Semestre 11
                    new() { Name = "Medical Internship II", WorkloadHours = 160, CreationDate = DateTime.Parse("2016-11-01") },
                    new() { Name = "Medical Internship III", WorkloadHours = 160, CreationDate = DateTime.Parse("2016-11-02") },
                    new() { Name = "Emergency Medicine", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-11-03") },
                    new() { Name = "Intensive Care", WorkloadHours = 80, CreationDate = DateTime.Parse("2016-11-04") },

                    // Semestre 12
                    new() { Name = "Medical Internship IV", WorkloadHours = 160, CreationDate = DateTime.Parse("2016-12-01") },
                    new() { Name = "Medical Internship V", WorkloadHours = 160, CreationDate = DateTime.Parse("2016-12-02") },
                    new() { Name = "Final Medical Course", WorkloadHours = 100, CreationDate = DateTime.Parse("2016-12-03") },
                    new() { Name = "Medical Residency Preparation", WorkloadHours = 60, CreationDate = DateTime.Parse("2016-12-04") }
                };

                modules.AddRange(medicineModules);
                #endregion

                context.Modules.AddRange(modules);
                context.SaveChanges();
            }
            #endregion

            #region CourseModules
            if (!context.CourseModules.Any())
            {
                var courseModules = new List<CourseModule>();
                var dayOfWeeks = new[] { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

                var courses = context.Courses.ToList();
                var modules = context.Modules.ToList();

                #region Computer Science
                var computerScienceCourse = courses.First(c => c.Name == "Computer Science");
                var computerScienceSemesters = new[]
                {
                    // Semestre 1
                    new {
                        ModuleNames = new[] {
                            "Introduction to Computing", "Algorithm and Programming Logic", "Calculus I",
                            "Discrete Mathematics", "Digital Systems", "Technical Communication"
                        },
                        Semester = 1
                    },
                    // Semestre 2
                    new {
                        ModuleNames = new[] {
                            "Object-Oriented Programming", "Data Structures", "Calculus II",
                            "Computer Architecture", "Linear Algebra"
                        },
                        Semester = 2
                    },
                    // Semestre 3
                    new {
                        ModuleNames = new[] {
                            "Algorithms and Complexity", "Database Systems I", "Operating Systems",
                            "Probability and Statistics", "Software Engineering I"
                        },
                        Semester = 3
                    },
                    // Semestre 4
                    new {
                        ModuleNames = new[] {
                            "Database Systems II", "Computer Networks", "Web Development",
                            "Software Engineering II", "Human-Computer Interaction"
                        },
                        Semester = 4
                    },
                    // Semestre 5
                    new {
                        ModuleNames = new[] {
                            "Artificial Intelligence", "Compilers", "Distributed Systems",
                            "Computer Graphics", "Formal Languages and Automata"
                        },
                        Semester = 5
                    },
                    // Semestre 6
                    new {
                        ModuleNames = new[] {
                            "Machine Learning", "Mobile Development", "Information Security",
                            "Software Testing and Quality", "Cloud Computing"
                        },
                        Semester = 6
                    },
                    // Semestre 7
                    new {
                        ModuleNames = new[] {
                            "Software Project Management", "Entrepreneurship in Computing", "Professional Ethics",
                            "Internship I", "Final Project I"
                        },
                        Semester = 7
                    },
                    // Semestre 8
                    new {
                        ModuleNames = new[] {
                            "Advanced Topics in Computing", "Internship II", "Final Project II",
                            "Career Planning"
                        },
                        Semester = 8
                    }
                };

                foreach (var semesterData in computerScienceSemesters)
                {
                    for (int i = 0; i < semesterData.ModuleNames.Length; i++)
                    {
                        var module = modules.First(m => m.Name == semesterData.ModuleNames[i] && m.CreationDate.Year == 2020);
                        courseModules.Add(new CourseModule
                        {
                            CourseID = computerScienceCourse.ID,
                            ModuleID = module.ID,
                            Semester = semesterData.Semester,
                            DayOfWeek = dayOfWeeks[i % dayOfWeeks.Length]
                        });
                    }
                }
                #endregion

                #region Computer Engineering
                var computerEngineeringCourse = courses.First(c => c.Name == "Computer Engineering");
                var computerEngineeringSemesters = new[]
                {
                    // Semestre 1
                    new {
                        ModuleNames = new[] {
                            "Engineering Calculus I", "General Physics I", "Technical Drawing",
                            "Introduction to Engineering", "Chemistry for Engineering"
                        },
                        Semester = 1
                    },
                    // Semestre 2
                    new {
                        ModuleNames = new[] {
                            "Engineering Calculus II", "General Physics II", "Algorithm and Programming Logic",
                            "Linear Algebra", "Experimental Physics"
                        },
                        Semester = 2
                    },
                    // Semestre 3
                    new {
                        ModuleNames = new[] {
                            "Electrical Circuits I", "Digital Systems", "Object-Oriented Programming",
                            "Differential Equations", "Numerical Calculus"
                        },
                        Semester = 3
                    },
                    // Semestre 4
                    new {
                        ModuleNames = new[] {
                            "Electrical Circuits II", "Electronics I", "Microprocessors",
                            "Data Structures", "Probability and Statistics"
                        },
                        Semester = 4
                    },
                    // Semestre 5
                    new {
                        ModuleNames = new[] {
                            "Electronics II", "Computer Architecture", "Signals and Systems",
                            "Algorithms and Complexity", "Database Systems"
                        },
                        Semester = 5
                    },
                    // Semestre 6
                    new {
                        ModuleNames = new[] {
                            "Embedded Systems", "Control Systems", "Operating Systems",
                            "Computer Networks", "Software Engineering"
                        },
                        Semester = 6
                    },
                    // Semestre 7
                    new {
                        ModuleNames = new[] {
                            "Digital Signal Processing", "VLSI Design", "Real-Time Systems",
                            "Computer Networks II", "Engineering Economics"
                        },
                        Semester = 7
                    },
                    // Semestre 8
                    new {
                        ModuleNames = new[] {
                            "Industrial Automation", "Robotics", "Digital Control Systems",
                            "Instrumentation", "Engineering Project I"
                        },
                        Semester = 8
                    },
                    // Semestre 9
                    new {
                        ModuleNames = new[] {
                            "Artificial Intelligence", "Computer Vision", "Internet of Things",
                            "Embedded Software", "Engineering Project II"
                        },
                        Semester = 9
                    },
                    // Semestre 10
                    new {
                        ModuleNames = new[] {
                            "Professional Practice", "Final Engineering Project", "Engineering Management",
                            "Technical Entrepreneurship"
                        },
                        Semester = 10
                    }
                };

                foreach (var semesterData in computerEngineeringSemesters)
                {
                    for (int i = 0; i < semesterData.ModuleNames.Length; i++)
                    {
                        var module = modules.First(m => m.Name == semesterData.ModuleNames[i] && m.CreationDate.Year == 2019);
                        courseModules.Add(new CourseModule
                        {
                            CourseID = computerEngineeringCourse.ID,
                            ModuleID = module.ID,
                            Semester = semesterData.Semester,
                            DayOfWeek = dayOfWeeks[i % dayOfWeeks.Length]
                        });
                    }
                }
                #endregion

                #region Agronomy
                var agronomyCourse = courses.First(c => c.Name == "Agronomy");
                var agronomySemesters = new[]
                {
                    // Semestre 1
                    new {
                        ModuleNames = new[] {
                            "Introduction to Agronomy", "General Botany", "General Chemistry",
                            "Mathematics for Agronomy", "Technical Drawing"
                        },
                        Semester = 1
                    },
                    // Semestre 2
                    new {
                        ModuleNames = new[] {
                            "Plant Physiology", "Organic Chemistry", "Soil Science",
                            "Biochemistry", "Statistics"
                        },
                        Semester = 2
                    },
                    // Semestre 3
                    new {
                        ModuleNames = new[] {
                            "Plant Morphology", "Soil Fertility", "Agricultural Microbiology",
                            "Agricultural Climatology", "Agricultural Entomology"
                        },
                        Semester = 3
                    },
                    // Semestre 4
                    new {
                        ModuleNames = new[] {
                            "Plant Nutrition", "Phytopathology", "Forage Crops",
                            "Cereal Crops", "Weed Science"
                        },
                        Semester = 4
                    },
                    // Semestre 5
                    new {
                        ModuleNames = new[] {
                            "Agricultural Machinery", "Irrigation and Drainage", "Soil Conservation",
                            "Agricultural Genetics", "Plant Breeding"
                        },
                        Semester = 5
                    },
                    // Semestre 6
                    new {
                        ModuleNames = new[] {
                            "Fruit Culture", "Vegetable Crops", "Agricultural Pesticides",
                            "Organic Agriculture", "Agricultural Zootechnics"
                        },
                        Semester = 6
                    },
                    // Semestre 7
                    new {
                        ModuleNames = new[] {
                            "Agricultural Management", "Rural Economics", "Agricultural Marketing",
                            "Rural Extension", "Agricultural Project I"
                        },
                        Semester = 7
                    },
                    // Semestre 8
                    new {
                        ModuleNames = new[] {
                            "Agricultural Legislation", "Environmental Management", "Precision Agriculture",
                            "Agricultural Project II", "Professional Internship"
                        },
                        Semester = 8
                    }
                };

                foreach (var semesterData in agronomySemesters)
                {
                    for (int i = 0; i < semesterData.ModuleNames.Length; i++)
                    {
                        var module = modules.First(m => m.Name == semesterData.ModuleNames[i] && m.CreationDate.Year == 2018);
                        courseModules.Add(new CourseModule
                        {
                            CourseID = agronomyCourse.ID,
                            ModuleID = module.ID,
                            Semester = semesterData.Semester,
                            DayOfWeek = dayOfWeeks[i % dayOfWeeks.Length]
                        });
                    }
                }
                #endregion

                #region Mathematics
                var mathematicsCourse = courses.First(c => c.Name == "Mathematics (Teaching Degree)");
                var mathematicsSemesters = new[]
                {
                    // Semestre 1
                    new {
                        ModuleNames = new[] {
                            "Differential and Integral Calculus I", "Vector Geometry and Linear Algebra", "Mathematical Logic",
                            "Introduction to Higher Mathematics", "Portuguese Language"
                        },
                        Semester = 1
                    },
                    // Semestre 2
                    new {
                        ModuleNames = new[] {
                            "Differential and Integral Calculus II", "Analytic Geometry", "Theory of Sets",
                            "Computer Science for Mathematics", "Philosophy of Education"
                        },
                        Semester = 2
                    },
                    // Semestre 3
                    new {
                        ModuleNames = new[] {
                            "Differential and Integral Calculus III", "Abstract Algebra I", "Numerical Calculus",
                            "Probability and Statistics I", "Educational Psychology"
                        },
                        Semester = 3
                    },
                    // Semestre 4
                    new {
                        ModuleNames = new[] {
                            "Differential Equations", "Abstract Algebra II", "Real Analysis I",
                            "Probability and Statistics II", "History of Mathematics"
                        },
                        Semester = 4
                    },
                    // Semestre 5
                    new {
                        ModuleNames = new[] {
                            "Complex Analysis", "Linear Algebra", "Real Analysis II",
                            "Mathematical Modeling", "Teaching Methodology I"
                        },
                        Semester = 5
                    },
                    // Semestre 6
                    new {
                        ModuleNames = new[] {
                            "Topology", "Number Theory", "Geometry",
                            "Teaching Methodology II", "Educational Technology"
                        },
                        Semester = 6
                    },
                    // Semestre 7
                    new {
                        ModuleNames = new[] {
                            "Functional Analysis", "Discrete Mathematics", "Mathematics Teaching Internship I",
                            "Scientific Research Methodology", "Educational Assessment"
                        },
                        Semester = 7
                    },
                    // Semestre 8
                    new {
                        ModuleNames = new[] {
                            "Mathematics Teaching Internship II", "Final Course Project", "Special Topics in Mathematics",
                            "School Management", "Educational Legislation"
                        },
                        Semester = 8
                    }
                };

                foreach (var semesterData in mathematicsSemesters)
                {
                    for (int i = 0; i < semesterData.ModuleNames.Length; i++)
                    {
                        var module = modules.First(m => m.Name == semesterData.ModuleNames[i] && m.CreationDate.Year == 2017);
                        courseModules.Add(new CourseModule
                        {
                            CourseID = mathematicsCourse.ID,
                            ModuleID = module.ID,
                            Semester = semesterData.Semester,
                            DayOfWeek = dayOfWeeks[i % dayOfWeeks.Length]
                        });
                    }
                }
                #endregion

                #region Medicine
                var medicineCourse = courses.First(c => c.Name == "Medicine");
                var medicineSemesters = new[]
                {
                    // Semestre 1
                    new {
                        ModuleNames = new[] {
                            "Human Anatomy I", "Medical Histology", "Medical Embryology",
                            "Biochemistry I", "Introduction to Medicine"
                        },
                        Semester = 1
                    },
                    // Semestre 2
                    new {
                        ModuleNames = new[] {
                            "Human Anatomy II", "Medical Physiology I", "Medical Genetics",
                            "Biochemistry II", "Medical Psychology"
                        },
                        Semester = 2
                    },
                    // Semestre 3
                    new {
                        ModuleNames = new[] {
                            "Medical Physiology II", "Medical Biophysics", "Medical Immunology",
                            "Medical Parasitology", "Medical Ethics I"
                        },
                        Semester = 3
                    },
                    // Semestre 4
                    new {
                        ModuleNames = new[] {
                            "General Pathology", "Medical Microbiology", "Pharmacology I",
                            "Medical Semiology I", "Epidemiology"
                        },
                        Semester = 4
                    },
                    // Semestre 5
                    new {
                        ModuleNames = new[] {
                            "Internal Medicine I", "Surgical Technique", "Pharmacology II",
                            "Medical Semiology II", "Medical Propaedeutics"
                        },
                        Semester = 5
                    },
                    // Semestre 6
                    new {
                        ModuleNames = new[] {
                            "Internal Medicine II", "General Surgery", "Pediatrics I",
                            "Obstetrics I", "Medical Ethics II"
                        },
                        Semester = 6
                    },
                    // Semestre 7
                    new {
                        ModuleNames = new[] {
                            "Cardiology", "Pulmonology", "Gastroenterology",
                            "Nephrology", "Endocrinology"
                        },
                        Semester = 7
                    },
                    // Semestre 8
                    new {
                        ModuleNames = new[] {
                            "Neurology", "Psychiatry", "Dermatology",
                            "Ophthalmology", "Otorhinolaryngology"
                        },
                        Semester = 8
                    },
                    // Semestre 9
                    new {
                        ModuleNames = new[] {
                            "Orthopedics", "Urology", "Anesthesiology",
                            "Pediatrics II", "Obstetrics II"
                        },
                        Semester = 9
                    },
                    // Semestre 10
                    new {
                        ModuleNames = new[] {
                            "Preventive Medicine", "Family and Community Medicine", "Public Health",
                            "Medical Law", "Medical Internship I"
                        },
                        Semester = 10
                    },
                    // Semestre 11
                    new {
                        ModuleNames = new[] {
                            "Medical Internship II", "Medical Internship III", "Emergency Medicine",
                            "Intensive Care"
                        },
                        Semester = 11
                    },
                    // Semestre 12
                    new {
                        ModuleNames = new[] {
                            "Medical Internship IV", "Medical Internship V", "Final Medical Course",
                            "Medical Residency Preparation"
                        },
                        Semester = 12
                    }
                };

                foreach (var semesterData in medicineSemesters)
                {
                    for (int i = 0; i < semesterData.ModuleNames.Length; i++)
                    {
                        var module = modules.First(m => m.Name == semesterData.ModuleNames[i] && m.CreationDate.Year == 2016);
                        courseModules.Add(new CourseModule
                        {
                            CourseID = medicineCourse.ID,
                            ModuleID = module.ID,
                            Semester = semesterData.Semester,
                            DayOfWeek = dayOfWeeks[i % dayOfWeeks.Length]
                        });
                    }
                }
                #endregion

                context.CourseModules.AddRange(courseModules);
                context.SaveChanges();
            }
            #endregion

            #region Module Prerequisites
            if (!context.ModulePrerequisites.Any())
            {
                var prerequisites = new List<ModulePrerequisite>();

                var modules = context.Modules.ToList();

                #region Computer Science
                var computerSciencePrerequisites = new[]
                {
                    ("Object-Oriented Programming", "Algorithm and Programming Logic"),
                    ("Data Structures", "Algorithm and Programming Logic"),
                    ("Calculus II", "Calculus I"),
                    ("Algorithms and Complexity", "Data Structures"),
                    ("Database Systems I", "Object-Oriented Programming"),
                    ("Database Systems II", "Database Systems I"),
                    ("Artificial Intelligence", "Algorithms and Complexity"),
                    ("Machine Learning", "Artificial Intelligence"),
                    ("Final Project I", "Software Engineering II"),
                    ("Final Project II", "Final Project I")
                };
                #endregion

                #region Computer Engineering
                var computerEngineeringPrerequisites = new[]
                {
                    ("Engineering Calculus II", "Engineering Calculus I"),
                    ("General Physics II", "General Physics I"),
                    ("Electrical Circuits I", "Engineering Calculus II"),
                    ("Electrical Circuits II", "Electrical Circuits I"),
                    ("Electronics I", "Digital Systems"),
                    ("Electronics II", "Electronics I"),
                    ("Embedded Systems", "Electronics II"),
                    ("Engineering Project I", "Software Engineering"),
                    ("Engineering Project II", "Engineering Project I"),
                    ("Final Engineering Project", "Engineering Project II")
                };
                #endregion

                #region Agronomy
                var agronomyPrerequisites = new[]
                {
                    ("Plant Physiology", "General Botany"),
                    ("Soil Fertility", "Soil Science"),
                    ("Plant Nutrition", "Plant Physiology"),
                    ("Agricultural Machinery", "Soil Science"),
                    ("Agricultural Project I", "Agricultural Management"),
                    ("Agricultural Project II", "Agricultural Project I")
                };
                #endregion

                #region Mathematics
                var mathematicsPrerequisites = new[]
                {
                    ("Differential and Integral Calculus II", "Differential and Integral Calculus I"),
                    ("Differential and Integral Calculus III", "Differential and Integral Calculus II"),
                    ("Differential Equations", "Differential and Integral Calculus III"),
                    ("Abstract Algebra II", "Abstract Algebra I"),
                    ("Real Analysis II", "Real Analysis I"),
                    ("Mathematics Teaching Internship I", "Teaching Methodology II"),
                    ("Mathematics Teaching Internship II", "Mathematics Teaching Internship I"),
                    ("Final Course Project", "Scientific Research Methodology")
                };
                #endregion

                #region Medicine
                var medicinePrerequisites = new[]
                {
                    ("Human Anatomy II", "Human Anatomy I"),
                    ("Medical Physiology II", "Medical Physiology I"),
                    ("General Pathology", "Medical Physiology II"),
                    ("Internal Medicine I", "General Pathology"),
                    ("Internal Medicine II", "Internal Medicine I"),
                    ("Medical Internship I", "Internal Medicine II"),
                    ("Medical Internship II", "Medical Internship I"),
                    ("Medical Internship III", "Medical Internship II"),
                    ("Medical Internship IV", "Medical Internship III"),
                    ("Medical Internship V", "Medical Internship IV")
                };
                #endregion

                // Funcao auxiliar para adicionar pre-requisitos
                void AddPrerequisites((string ModuleName, string PrerequisiteName)[] prereqList)
                {
                    foreach (var (moduleName, prerequisiteName) in prereqList)
                    {
                        var module = modules.FirstOrDefault(m => m.Name == moduleName);
                        var prerequisite = modules.FirstOrDefault(m => m.Name == prerequisiteName);

                        if (module != null && prerequisite != null)
                        {
                            prerequisites.Add(new ModulePrerequisite
                            {
                                ModuleID = module.ID,
                                PrerequisiteID = prerequisite.ID
                            });
                        }
                    }
                }

                // Adicionando
                AddPrerequisites(computerSciencePrerequisites);
                AddPrerequisites(computerEngineeringPrerequisites);
                AddPrerequisites(agronomyPrerequisites);
                AddPrerequisites(mathematicsPrerequisites);
                AddPrerequisites(medicinePrerequisites);

                context.ModulePrerequisites.AddRange(prerequisites);
                context.SaveChanges();
            }
            #endregion

            #region StudentCourse
            if (!context.StudentCourses.Any())
            {
                var studentCourses = new StudentCourse[]
                {
                    // Computer Science
                    new() { StudentID = 1, CourseID = 1, SignDate = DateTime.Parse("2023-08-15") },
                    new() { StudentID = 2, CourseID = 1, SignDate = DateTime.Parse("2023-08-22") },
                    new() { StudentID = 3, CourseID = 1, SignDate = DateTime.Parse("2023-03-10") },

                    // Computer Engineering
                    new() { StudentID = 4, CourseID = 2, SignDate = DateTime.Parse("2023-08-18") },
                    new() { StudentID = 5, CourseID = 2, SignDate = DateTime.Parse("2023-08-25") },
                    new() { StudentID = 6, CourseID = 2, SignDate = DateTime.Parse("2022-08-30") },

                    // Agronomy
                    new() { StudentID = 7, CourseID = 3, SignDate = DateTime.Parse("2023-08-12") },
                    new() { StudentID = 8, CourseID = 3, SignDate = DateTime.Parse("2023-08-28") },
                    new() { StudentID = 9, CourseID = 3, SignDate = DateTime.Parse("2022-08-15") },

                    // Mathematics
                    new() { StudentID = 10, CourseID = 4, SignDate = DateTime.Parse("2023-08-20") },
                    new() { StudentID = 11, CourseID = 4, SignDate = DateTime.Parse("2023-08-08") },
                    new() { StudentID = 12, CourseID = 4, SignDate = DateTime.Parse("2022-09-05") },

                    // Medicine
                    new() { StudentID = 1, CourseID = 5, SignDate = DateTime.Parse("2024-01-15") },
                    new() { StudentID = 2, CourseID = 5, SignDate = DateTime.Parse("2024-02-01") },
                    new() { StudentID = 3, CourseID = 5, SignDate = DateTime.Parse("2023-08-10") },
                    new() { StudentID = 4, CourseID = 5, SignDate = DateTime.Parse("2023-08-05") },
                    new() { StudentID = 5, CourseID = 5, SignDate = DateTime.Parse("2022-08-20") },
                    new() { StudentID = 6, CourseID = 5, SignDate = DateTime.Parse("2022-08-25") },

                    // Estudantes em mais de um curso
                    new() { StudentID = 7, CourseID = 1, SignDate = DateTime.Parse("2024-01-20") },
                    new() { StudentID = 8, CourseID = 4, SignDate = DateTime.Parse("2024-02-10") },
                    new() { StudentID = 9, CourseID = 2, SignDate = DateTime.Parse("2023-07-15") },
                    new() { StudentID = 10, CourseID = 3, SignDate = DateTime.Parse("2024-03-01") },
                    new() { StudentID = 11, CourseID = 1, SignDate = DateTime.Parse("2023-11-15") },
                    new() { StudentID = 12, CourseID = 2, SignDate = DateTime.Parse("2023-12-05") }
                };

                context.StudentCourses.AddRange(studentCourses);
                context.SaveChanges();
            }
            #endregion

            #region StudentModules
            if (!context.StudentModules.Any())
            {
                var studentModules = new List<StudentModule>();

                var allStudents = context.Students.ToList();
                var courses = context.Courses.ToList();
                var modules = context.Modules.ToList();
                var courseModules = context.CourseModules.ToList();

                var studentModuleData = new object []
                {
                    #region Computer Science
                    // Student 1 
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Introduction to Computing", CourseName = "Computer Science", Grade = 9.2, Frequency = 94, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Algorithm and Programming Logic", CourseName = "Computer Science", Grade = 9.5, Frequency = 96, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Calculus I", CourseName = "Computer Science", Grade = 8.8, Frequency = 90, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Discrete Mathematics", CourseName = "Computer Science", Grade = 9.0, Frequency = 92, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Object-Oriented Programming", CourseName = "Computer Science", Grade = 8.7, Frequency = 89, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Data Structures", CourseName = "Computer Science", Grade = 8.9, Frequency = 91, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Calculus II", CourseName = "Computer Science", Grade = 7.8, Frequency = 84, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Computer Architecture", CourseName = "Computer Science", Grade = 8.5, Frequency = 88, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Database Systems II", CourseName = "Computer Science", Grade = 8.5, Frequency = 88, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Computer Networks", CourseName = "Computer Science", Grade = 8.2, Frequency = 86, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Web Development", CourseName = "Computer Science", Grade = 9.1, Frequency = 93, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Software Engineering II", CourseName = "Computer Science", Grade = 8.8, Frequency = 90, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Artificial Intelligence", CourseName = "Computer Science", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Matheus", StudentLastName = "Fribel", ModuleName = "Machine Learning", CourseName = "Computer Science", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 2 
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Introduction to Computing", CourseName = "Computer Science", Grade = 7.5, Frequency = 82, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Algorithm and Programming Logic", CourseName = "Computer Science", Grade = 7.8, Frequency = 84, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Calculus I", CourseName = "Computer Science", Grade = 6.9, Frequency = 78, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Object-Oriented Programming", CourseName = "Computer Science", Grade = 6.8, Frequency = 76, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Data Structures", CourseName = "Computer Science", Grade = 7.2, Frequency = 79, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Operating Systems", CourseName = "Computer Science", Grade = 7.0, Frequency = 77, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Database Systems II", CourseName = "Computer Science", Grade = 7.0, Frequency = 78, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Computer Networks", CourseName = "Computer Science", Grade = 6.9, Frequency = 77, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Meredith", StudentLastName = "Alonso", ModuleName = "Information Security", CourseName = "Computer Science", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    #endregion

                    #region Computer Engineering
                    // Student 3
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Engineering Calculus I", CourseName = "Computer Engineering", Grade = 8.5, Frequency = 88, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "General Physics I", CourseName = "Computer Engineering", Grade = 8.2, Frequency = 86, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Technical Drawing", CourseName = "Computer Engineering", Grade = 8.8, Frequency = 91, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Engineering Calculus II", CourseName = "Computer Engineering", Grade = 7.8, Frequency = 83, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "General Physics II", CourseName = "Computer Engineering", Grade = 8.0, Frequency = 85, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Algorithm and Programming Logic", CourseName = "Computer Engineering", Grade = 9.0, Frequency = 92, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Electrical Circuits II", CourseName = "Computer Engineering", Grade = 8.2, Frequency = 86, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Electronics I", CourseName = "Computer Engineering", Grade = 8.5, Frequency = 88, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Microprocessors", CourseName = "Computer Engineering", Grade = 8.7, Frequency = 89, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Embedded Systems", CourseName = "Computer Engineering", Grade = 8.7, Frequency = 89, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Control Systems", CourseName = "Computer Engineering", Grade = 8.3, Frequency = 87, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Operating Systems", CourseName = "Computer Engineering", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Computer Networks", CourseName = "Computer Engineering", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 4
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Engineering Calculus I", CourseName = "Computer Engineering", Grade = 7.2, Frequency = 79, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "General Physics I", CourseName = "Computer Engineering", Grade = 6.9, Frequency = 77, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Engineering Calculus II", CourseName = "Computer Engineering", Grade = 7.0, Frequency = 78, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "General Physics II", CourseName = "Computer Engineering", Grade = 6.8, Frequency = 76, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Digital Systems", CourseName = "Computer Engineering", Grade = 7.5, Frequency = 81, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Electrical Circuits II", CourseName = "Computer Engineering", Grade = 7.2, Frequency = 79, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Electronics I", CourseName = "Computer Engineering", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Data Structures", CourseName = "Computer Engineering", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    #endregion

                    #region Agronomy
                    // Student 5
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Introduction to Agronomy", CourseName = "Agronomy", Grade = 8.0, Frequency = 85, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "General Botany", CourseName = "Agronomy", Grade = 8.3, Frequency = 87, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "General Chemistry", CourseName = "Agronomy", Grade = 7.9, Frequency = 84, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Plant Physiology", CourseName = "Agronomy", Grade = 7.9, Frequency = 82, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Organic Chemistry", CourseName = "Agronomy", Grade = 8.1, Frequency = 84, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Soil Science", CourseName = "Agronomy", Grade = 8.4, Frequency = 87, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Plant Nutrition", CourseName = "Agronomy", Grade = 8.3, Frequency = 86, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Phytopathology", CourseName = "Agronomy", Grade = 8.0, Frequency = 83, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Agricultural Microbiology", CourseName = "Agronomy", Grade = 8.2, Frequency = 85, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Fruit Culture", CourseName = "Agronomy", Grade = 8.5, Frequency = 87, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Vegetable Crops", CourseName = "Agronomy", Grade = 8.2, Frequency = 85, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Agricultural Pesticides", CourseName = "Agronomy", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Organic Agriculture", CourseName = "Agronomy", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 6
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Introduction to Agronomy", CourseName = "Agronomy", Grade = 6.8, Frequency = 76, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "General Botany", CourseName = "Agronomy", Grade = 7.0, Frequency = 78, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Plant Physiology", CourseName = "Agronomy", Grade = 6.5, Frequency = 75, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Organic Chemistry", CourseName = "Agronomy", Grade = 7.0, Frequency = 78, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Soil Science", CourseName = "Agronomy", Grade = 6.9, Frequency = 77, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Plant Nutrition", CourseName = "Agronomy", Grade = 7.2, Frequency = 79, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Phytopathology", CourseName = "Agronomy", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Forage Crops", CourseName = "Agronomy", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    #endregion

                    #region Mathematics
                    // Student 7
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Differential and Integral Calculus I", CourseName = "Mathematics (Teaching Degree)", Grade = 9.3, Frequency = 95, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Vector Geometry and Linear Algebra", CourseName = "Mathematics (Teaching Degree)", Grade = 9.5, Frequency = 96, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Differential and Integral Calculus II", CourseName = "Mathematics (Teaching Degree)", Grade = 9.0, Frequency = 92, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Analytic Geometry", CourseName = "Mathematics (Teaching Degree)", Grade = 9.2, Frequency = 94, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Differential and Integral Calculus III", CourseName = "Mathematics (Teaching Degree)", Grade = 8.9, Frequency = 91, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Abstract Algebra I", CourseName = "Mathematics (Teaching Degree)", Grade = 9.1, Frequency = 93, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Differential Equations", CourseName = "Mathematics (Teaching Degree)", Grade = 8.8, Frequency = 91, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Abstract Algebra II", CourseName = "Mathematics (Teaching Degree)", Grade = 9.1, Frequency = 93, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Topology", CourseName = "Mathematics (Teaching Degree)", Grade = 8.9, Frequency = 92, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Number Theory", CourseName = "Mathematics (Teaching Degree)", Grade = 9.0, Frequency = 93, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Mathematics Teaching Internship II", CourseName = "Mathematics (Teaching Degree)", Grade = 9.3, Frequency = 95, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Final Course Project", CourseName = "Mathematics (Teaching Degree)", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Object-Oriented Programming", CourseName = "Computer Science", Grade = 8.5, Frequency = 87, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Laura", StudentLastName = "Norman", ModuleName = "Data Structures", CourseName = "Computer Science", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 8
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Differential and Integral Calculus I", CourseName = "Mathematics (Teaching Degree)", Grade = 7.8, Frequency = 84, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Vector Geometry and Linear Algebra", CourseName = "Mathematics (Teaching Degree)", Grade = 7.6, Frequency = 82, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Differential and Integral Calculus II", CourseName = "Mathematics (Teaching Degree)", Grade = 7.5, Frequency = 81, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Analytic Geometry", CourseName = "Mathematics (Teaching Degree)", Grade = 7.2, Frequency = 79, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Differential Equations", CourseName = "Mathematics (Teaching Degree)", Grade = 7.0, Frequency = 78, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Abstract Algebra II", CourseName = "Mathematics (Teaching Degree)", Grade = 7.3, Frequency = 80, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Topology", CourseName = "Mathematics (Teaching Degree)", Grade = 7.1, Frequency = 79, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Geometry", CourseName = "Mathematics (Teaching Degree)", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Plant Physiology", CourseName = "Agronomy", Grade = 7.8, Frequency = 82, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Nino", StudentLastName = "Olivetto", ModuleName = "Soil Science", CourseName = "Agronomy", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    #endregion

                    #region Medicine 
                    // Student 3
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Human Anatomy I", CourseName = "Medicine", Grade = 8.5, Frequency = 88, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Medical Histology", CourseName = "Medicine", Grade = 8.2, Frequency = 86, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Arturo", StudentLastName = "Anand", ModuleName = "Human Anatomy II", CourseName = "Medicine", Grade = 8.0, Frequency = 85, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 4
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Human Anatomy I", CourseName = "Medicine", Grade = 7.8, Frequency = 83, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Medical Histology", CourseName = "Medicine", Grade = 7.5, Frequency = 81, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Gytis", StudentLastName = "Barzdukas", ModuleName = "Human Anatomy II", CourseName = "Medicine", Grade = 7.2, Frequency = 79, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 5
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Human Anatomy I", CourseName = "Medicine", Grade = 8.8, Frequency = 90, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-08-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Medical Histology", CourseName = "Medicine", Grade = 8.5, Frequency = 88, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-08-01") },
                    new { StudentName = "Yan", StudentLastName = "Li", ModuleName = "Medical Physiology I", CourseName = "Medicine", Grade = 8.3, Frequency = 87, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 6
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Human Anatomy I", CourseName = "Medicine", Grade = 7.0, Frequency = 78, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-08-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Medical Histology", CourseName = "Medicine", Grade = 6.8, Frequency = 76, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-08-01") },
                    new { StudentName = "Peggy", StudentLastName = "Justice", ModuleName = "Medical Physiology I", CourseName = "Medicine", Grade = 6.9, Frequency = 77, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 9
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Human Anatomy I", CourseName = "Medicine", Grade = 9.6, Frequency = 97, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2021-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Medical Histology", CourseName = "Medicine", Grade = 9.4, Frequency = 96, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2021-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Human Anatomy II", CourseName = "Medicine", Grade = 9.4, Frequency = 95, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2021-07-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Medical Physiology I", CourseName = "Medicine", Grade = 9.2, Frequency = 94, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2021-07-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Medical Physiology II", CourseName = "Medicine", Grade = 9.3, Frequency = 95, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Medical Immunology", CourseName = "Medicine", Grade = 9.5, Frequency = 96, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "General Pathology", CourseName = "Medicine", Grade = 9.1, Frequency = 93, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Medical Microbiology", CourseName = "Medicine", Grade = 9.3, Frequency = 95, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Internal Medicine I", CourseName = "Medicine", Grade = 9.2, Frequency = 94, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Internal Medicine II", CourseName = "Medicine", Grade = 9.0, Frequency = 94, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "General Surgery", CourseName = "Medicine", Grade = 9.2, Frequency = 95, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Neurology", CourseName = "Medicine", Grade = 9.1, Frequency = 94, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Psychiatry", CourseName = "Medicine", Grade = 9.3, Frequency = 95, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Preventive Medicine", CourseName = "Medicine", Grade = 9.2, Frequency = 94, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Family and Community Medicine", CourseName = "Medicine", Grade = 9.4, Frequency = 96, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-07-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Medical Internship IV", CourseName = "Medicine", Grade = 9.5, Frequency = 97, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "John", StudentLastName = "Smith", ModuleName = "Medical Internship V", CourseName = "Medicine", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 10
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Human Anatomy I", CourseName = "Medicine", Grade = 8.2, Frequency = 86, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Medical Histology", CourseName = "Medicine", Grade = 8.0, Frequency = 85, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-01-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Human Anatomy II", CourseName = "Medicine", Grade = 8.0, Frequency = 85, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Medical Physiology I", CourseName = "Medicine", Grade = 7.8, Frequency = 83, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2022-07-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Medical Physiology II", CourseName = "Medicine", Grade = 8.1, Frequency = 85, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "General Pathology", CourseName = "Medicine", Grade = 8.2, Frequency = 86, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Medical Microbiology", CourseName = "Medicine", Grade = 7.9, Frequency = 84, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Internal Medicine II", CourseName = "Medicine", Grade = 8.1, Frequency = 85, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "General Surgery", CourseName = "Medicine", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Maria", StudentLastName = "Garcia", ModuleName = "Pediatrics I", CourseName = "Medicine", Grade = (double?)null, Frequency = (double?)null, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    #endregion

                    #region Multiple Courses
                    // Student 11
                    new { StudentName = "David", StudentLastName = "Johnson", ModuleName = "Differential and Integral Calculus I", CourseName = "Mathematics (Teaching Degree)", Grade = 8.5, Frequency = 88, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "David", StudentLastName = "Johnson", ModuleName = "Introduction to Computing", CourseName = "Computer Science", Grade = 8.7, Frequency = 89, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "David", StudentLastName = "Johnson", ModuleName = "Object-Oriented Programming", CourseName = "Computer Science", Grade = 8.3, Frequency = 86, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "David", StudentLastName = "Johnson", ModuleName = "Analytic Geometry", CourseName = "Mathematics (Teaching Degree)", Grade = 8.1, Frequency = 85, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },

                    // Student 12
                    new { StudentName = "Sarah", StudentLastName = "Williams", ModuleName = "Human Anatomy I", CourseName = "Medicine", Grade = 9.0, Frequency = 92, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Sarah", StudentLastName = "Williams", ModuleName = "Introduction to Computing", CourseName = "Computer Science", Grade = 8.8, Frequency = 90, Status = ModuleStatusEnum.Approved, SignDate = DateTime.Parse("2023-01-01") },
                    new { StudentName = "Sarah", StudentLastName = "Williams", ModuleName = "Medical Histology", CourseName = "Medicine", Grade = 8.9, Frequency = 91, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") },
                    new { StudentName = "Sarah", StudentLastName = "Williams", ModuleName = "Algorithm and Programming Logic", CourseName = "Computer Science", Grade = 8.6, Frequency = 88, Status = ModuleStatusEnum.Enrolled, SignDate = DateTime.Parse("2024-01-01") }
                    #endregion
                };

                // Verifica duplicadas
                var addedKeys = new HashSet<(int, int, int)>();

                foreach (var data in studentModuleData)
                {
                    // Usar dynamic para acessar as propriedades
                    dynamic dynamicData = data;

                    var student = allStudents.First(s => s.FirstMidName == dynamicData.StudentName && s.LastName == dynamicData.StudentLastName);
                    var course = courses.First(c => c.Name == dynamicData.CourseName);
                    var module = modules.First(m => m.Name == dynamicData.ModuleName);

                    var key = (student.ID, module.ID, course.ID);

                    // Verifica combinacao
                    if (!addedKeys.Contains(key))
                    {
                        studentModules.Add(new StudentModule
                        {
                            StudentID = student.ID,
                            ModuleID = module.ID,
                            CourseID = course.ID,
                            Grade = dynamicData.Grade,
                            Frequency = dynamicData.Frequency,
                            Status = dynamicData.Status,
                            SignDate = dynamicData.SignDate
                        });

                        addedKeys.Add(key);
                    }
                }

                context.StudentModules.AddRange(studentModules);
                context.SaveChanges();
            }
            #endregion
        }
    }
}