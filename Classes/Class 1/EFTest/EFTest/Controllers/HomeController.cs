using System.Diagnostics;
using EFTest.Data;
using EFTest.Models;
using EFTest.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class HomeController : Controller
    {
        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Others
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion
    }
}
