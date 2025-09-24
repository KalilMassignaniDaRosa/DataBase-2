using Microsoft.AspNetCore.Mvc;

namespace EFTest.Controllers
{
    public class ModuleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
