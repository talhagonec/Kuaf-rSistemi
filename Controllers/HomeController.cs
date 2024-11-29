using Microsoft.AspNetCore.Mvc;
using KuaforIsletmeYonetim.Models;
using System.Diagnostics;

namespace KuaforIsletmeYonetim.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Views/Home/Index.cshtml'e yönlendirir
        }

        public IActionResult Privacy()
        {
            return View(); // Views/Home/Privacy.cshtml'e yönlendirir
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
