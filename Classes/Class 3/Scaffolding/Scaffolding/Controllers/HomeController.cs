using System.Diagnostics;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Scaffolding.Models;

namespace Scaffolding.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public HomeController(
            ILogger<HomeController> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
            // Retorna um dicionario
            _connectionString = _config.GetSection("ConnectionStrings")["DefaultConnection"]!;
        }

        [HttpGet]
        public IActionResult Dapper()
        {
            using (
                SqlConnection connection = new (_connectionString)
            )
            {
                var data = connection.Query<Student>(
                    "SELECT *" +
                    "FROM Student");

                return View(data);
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
