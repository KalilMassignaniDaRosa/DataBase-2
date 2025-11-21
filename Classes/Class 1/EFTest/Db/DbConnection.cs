using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;

namespace Db
{
    public class DbConnection
    {
        private const string ConnectionString =
            "Driver={ODBC Driver 17 for SQL Server};"+
            "Server=(localdb)\\msqllocaldb;" +
            "Database=UnoescDB;" +
            "Trusted_Connection=Yes;";

        public static CreateConnection()
        {
            var connection = new OdbcConnection(ConnectionString);

            try
            {
                connection.Open();
                Console.Writeline("ODBC connection open with success!");
            }
            catch(Exception ex)
            {
                Console.Writeline("Error when opening the connetion: "+ex.Message);
            }

            return connection;

		}
    }
}
