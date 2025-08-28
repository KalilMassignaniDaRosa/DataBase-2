using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UnoescBank.Data;
using UnoescBank.Models;

namespace UnoescBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankContext _context;

        public HomeController(
            ILogger<HomeController> logger,
            BankContext context
        )
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Client()
        {
            var data = _context.Clients!
                            .Include(x => x.ClientAccounts!)
                                .ThenInclude(x => x.Account)
                            .ToList();

            return View("Client", data);
        }

        public IActionResult Account()
        {
            var data = _context.Accounts!
                .Include(x => x.ClientAccounts!)
                .ThenInclude(x => x.Client)
                .ToList();

            return View("Account", data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
