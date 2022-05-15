using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestAssignmentDesktop_Iliya_Vaveluk.Models;
using Newtonsoft.Json;

namespace TestAssignmentDesktop_Iliya_Vaveluk.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.currencies = APIController.GetTop10Currencies();
            return View();
        }

        public IActionResult Currency(string id)
        {
            ViewBag.currency = APIController.GetCurrency(id);
            ViewBag.markets = APIController.GetMarkets(id);
            ViewBag.history = APIController.GetHistory(id);
            ViewBag.exchanges = APIController.GetExchanges();
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