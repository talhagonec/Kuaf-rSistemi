using Microsoft.AspNetCore.Mvc;

namespace KuaforIsletmeYonetim.Controllers
{
    public class SalonViewController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Views/SalonView/Index.cshtml'e yönlendirir
        }

        public IActionResult Detay()
        {
            return View(); // Views/SalonView/Detay.cshtml'e yönlendirir
        }
    }
}
