using System;
using System.Data.Odbc;
using System.Globalization;

namespace Db
{
    public class CourseRepository
    {
        private readonly OdbcConnection _conn;

        public CourseRepository(OdbcConnection conn)
        {
            _conn = conn;
        }

        public void InsertCourse(string name, int numberOfSemesters = 0)
        {
            string sql = "INSERT INTO Course (Name, CreationDate, NumberOfSemesters) VALUES (?, ?, ?)";

            try
            {
                using (var cmd = new OdbcCommand(sql, _conn))
                {
                    var pName = new OdbcParameter("@name", OdbcType.NVarChar, 200)
                    {
                        Value = (object)name ?? DBNull.Value
                    };
                    cmd.Parameters.Add(pName); 

                    DateTime now = DateTime.Now;
                    DateTime truncated = new DateTime(
                        now.Year, now.Month, now.Day,
                        now.Hour, now.Minute, now.Second,
                        DateTimeKind.Unspecified);

                    string dateString = truncated.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);

                    var pDate = new OdbcParameter("@creationDate", OdbcType.NVarChar, 50)
                    {
                        Value = dateString
                    };
                    cmd.Parameters.Add(pDate);

                    var pSem = new OdbcParameter("@sem", OdbcType.Int)
                    {
                        Value = numberOfSemesters
                    };
                    cmd.Parameters.Add(pSem);

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
