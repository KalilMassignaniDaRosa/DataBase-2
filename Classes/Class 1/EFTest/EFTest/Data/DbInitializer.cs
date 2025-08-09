using EFTest.Models;
using System.Diagnostics;

namespace EFTest.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstMidName="Carson",LastName="Alexander"},
            new Student{FirstMidName="Meredith",LastName="Alonso"},
            new Student{FirstMidName="Arturo",LastName="Anand"},
            new Student{FirstMidName="Gytis",LastName="Barzdukas"},
            new Student{FirstMidName="Yan",LastName="Li"},
            new Student{FirstMidName="Peggy",LastName="Justice"},
            new Student{FirstMidName="Laura",LastName="Norman"},
            new Student{FirstMidName="Nino",LastName="Olivetto"}
            };
            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();
        }
    }
}
