using ExpensiveControlApp.Models;
using ExpensiveControlApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExpensiveControlApp.Controllers
{
    public class ExpensiveController : Controller
    {
        private readonly ILogger<ExpensiveController> _logger;
        private readonly IExpensiveService _expensiveService;

        public ExpensiveController(ILogger<ExpensiveController> logger, IExpensiveService expensiveService)
        {
            _logger = logger;
            _expensiveService = expensiveService;
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