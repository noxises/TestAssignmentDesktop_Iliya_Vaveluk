using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestAssignmentDesktop_Iliya_Vaveluk.Models;
using Microsoft.AspNetCore.Localization;


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


            ViewBag.allCurrencies = APIController.GetAllCurrencies().OrderBy(item => item.rank);
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

        string GetStringForJSArray(List<AllCurrenciesModel> list)
        {
            var array = "";
            foreach (var item in list)
            {
                array += "['" + item.name + " (" + item.symbol + ")'" + ",'" + item.priceUsd + "'],";
            }
            return array;
        }

        public IActionResult Converter()
        {
            var allCurrencies = APIController.GetAllCurrencies();
            ViewBag.allCurrencies = allCurrencies;
            ViewBag.JSArray = GetStringForJSArray(allCurrencies);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}