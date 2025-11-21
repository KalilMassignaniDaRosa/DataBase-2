using Db;

Console.WriteLine("ODBC Connection");

var conn = Db.DatabaseConnection.CreateConnection();

DatabaseQueries.ListCourses(conn);

Console.WriteLine("Type a course name to search: ");
string name = Console.ReadLine();

DatabaseQueries.SearchCourseByName(conn, name);

var repo = new CourseRepository(conn);

Console.WriteLine("Type a course name to insert: ");
name = Console.ReadLine();
repo.InsertCourse(name);

DatabaseQueries.ListCourses(conn);

conn.Close();
