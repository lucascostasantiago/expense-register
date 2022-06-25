using ExpensiveControlApp.DTOs;
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

        public async Task<IActionResult> Index()
        {
            var listExpensiveDTO = new ListExpensiveDTO();

            listExpensiveDTO.Items = await _expensiveService.FindBy(listExpensiveDTO.StartDate, listExpensiveDTO.EndDate);

            return View(listExpensiveDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Index(ListExpensiveDTO listExpensiveDTO)
        {
            try
            {
                listExpensiveDTO.Items = await _expensiveService.FindBy(listExpensiveDTO.StartDate, listExpensiveDTO.EndDate);

                return View(listExpensiveDTO);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(listExpensiveDTO);
            }
        }

        public async Task<IActionResult> Create()
        {
            var createExpensiveDTO = new CreateExpensiveDTO();

            return View(createExpensiveDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateExpensiveDTO createExpensiveDTO)
        {
            try
            {
                await _expensiveService.Create(createExpensiveDTO);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                return View(createExpensiveDTO);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}