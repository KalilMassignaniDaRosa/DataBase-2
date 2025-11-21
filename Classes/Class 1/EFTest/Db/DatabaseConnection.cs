using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db
{
    public class DatabaseConnection
    {
        private const string ConnectionString =
            "Driver={ODBC Driver 17 for SQL Server};" +
            "Server=(localdb)\\MSSQLLocalDB;" +
            "Database=UnoescBD2;" +
            "Trusted_Connection=Yes;";

        public static OdbcConnection CreateConnection()
        {
            var connection = new OdbcConnection(ConnectionString);

            try
            {
                connection.Open();
                Console.WriteLine("ODBC connection opened successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when opening the connection: " + ex.Message);
            }

            return connection;
        }
    }
}
