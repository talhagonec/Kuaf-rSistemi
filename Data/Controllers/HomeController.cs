using System.Diagnostics;
using KuaforDbSistemi.Models;
using Microsoft.AspNetCore.Mvc;

namespace KuaforDbSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Logger ba��ml�l��� i�in yap�c� metot
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana sayfa
        public IActionResult Index()
        {
            _logger.LogInformation("Ana sayfa y�klendi.");
            return View();
        }

        // Gizlilik politikas� sayfas�
        public IActionResult Privacy()
        {
            _logger.LogInformation("Gizlilik politikas� sayfas� y�klendi.");
            return View();
        }

        // Hata sayfas�
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            _logger.LogError("Bir hata olu�tu.");
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
