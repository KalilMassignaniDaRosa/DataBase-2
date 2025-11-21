using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public class CourseRepository
    {
        private readonly OdbcConnection _conn;

        public CourseRepository(OdbcConnection conn)
        {
            _conn = conn;
        }

        public void InsertCourse(string name)
        {
            string sql = "INSERT INTO Course (Name, CreationDate) VALUES (?, ?)";

            try
            {
                using (var cmd = new OdbcCommand(sql, _conn))
                {
                    var pName = new OdbcParameter("@name", OdbcType.NVarChar, 200);
                    pName.Value = name ?? (object)DBNull.Value;
                    cmd.Parameters.Add(pName);

                    DateTime now = DateTime.Now;
                    DateTime truncated = new DateTime(
                        now.Year, now.Month, now.Day,
                        now.Hour, now.Minute, now.Second,
                        now.Kind // UTC
                    );

                    var pDate = new OdbcParameter("@creationDate", OdbcType.Timestamp);
                    pDate.Value = truncated;
                    cmd.Parameters.Add(pDate);

                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine($"{rows} record(s) inserted successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
