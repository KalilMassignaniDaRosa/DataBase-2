using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public class DatabaseQueries
    {
        public static void ListCourses(OdbcConnection conn)
        {
            string sql = "SELECT ID, Name FROM Course";

            try
            {
                using (var cmd = new OdbcCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("=== Course List ===");

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.IsDBNull(1)
                            ? "(no name)"
                            : reader.GetString(1);

                        Console.WriteLine($"ID: {id} | Name: {name}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error querying Course table: " + ex.Message);
            }
        }

        public static void SearchCourseByName(OdbcConnection conn, string partialName)
        {
            string sql = "SELECT ID, Name FROM Course WHERE Name LIKE ?";

            try
            {
                using (var cmd = new OdbcCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", "%" + partialName + "%");

                    using (var reader = cmd.ExecuteReader())
                    {
                        Console.WriteLine($"=== Courses containing '{partialName}' ===");

                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.IsDBNull(1)
                                ? "(no name)"
                                : reader.GetString(1);

                            Console.WriteLine($"ID: {id}, Name: {name}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching for courses: {ex.Message}");
            }
        }
    }
}
