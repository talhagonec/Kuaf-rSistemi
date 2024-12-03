using Microsoft.AspNetCore.Mvc;
using KuaforIsletmeYonetim.Models; // Salon modeline erişim
using System.Linq;

namespace KuaforIsletmeYonetim.Controllers
{
    public class SalonViewController : Controller
    {
        private readonly KuaforContext _context;

        public SalonViewController(KuaforContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Salon Listesi
        public IActionResult Index()
        {
            var salonlar = _context.Salonlar?.ToList() ?? new List<Salon>(); // Null kontrolü
            return View(salonlar); // Views/SalonView/Index.cshtml'e veriyi gönder
        }

        // Salon Detayları
        [HttpGet]
        public IActionResult Detay(int id)
        {
            var salon = _context.Salonlar?.FirstOrDefault(s => s.Id == id); // Null kontrolü
            if (salon == null)
            {
                return NotFound(); // Salon bulunamazsa 404 döndür
            }
            return View(salon); // Views/SalonView/Detay.cshtml'e veriyi gönder
        }

        // Salon Ekle
        [HttpGet]
        public IActionResult Ekle()
        {
            return View(); // Views/SalonView/Ekle.cshtml'e yönlendirir
        }

        [HttpPost]
        public IActionResult Ekle(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salonlar?.Add(salon);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Başarılı eklemeden sonra listeye yönlendirme
            }
            return View(salon); // Hata varsa tekrar ekleme sayfasına döner
        }

        // Salon Düzenle
        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            var salon = _context.Salonlar?.FirstOrDefault(s => s.Id == id); // Null kontrolü
            if (salon == null)
            {
                return NotFound(); // Salon bulunamazsa 404 döndür
            }
            return View(salon); // Views/SalonView/Duzenle.cshtml'e yönlendirir
        }

        [HttpPost]
        public IActionResult Duzenle(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salonlar?.Update(salon);
                _context.SaveChanges();
                return RedirectToAction("Index"); // Düzenlemeden sonra listeye yönlendirme
            }
            return View(salon); // Hata varsa tekrar düzenleme sayfasına döner
        }

        // Salon Sil
        [HttpGet]
        public IActionResult Sil(int id)
        {
            var salon = _context.Salonlar?.FirstOrDefault(s => s.Id == id); // Null kontrolü
            if (salon == null)
            {
                return NotFound(); // Salon bulunamazsa 404 döndür
            }
            return View(salon); // Views/SalonView/Sil.cshtml'e yönlendirir
        }

        [HttpPost]
        public IActionResult SilConfirmed(int id)
        {
            var salon = _context.Salonlar?.FirstOrDefault(s => s.Id == id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.Salonlar?.Remove(salon);
            _context.SaveChanges();
            return RedirectToAction("Index"); // Silindikten sonra listeye yönlendirme
        }
    }
}
