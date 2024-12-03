using Microsoft.AspNetCore.Mvc;
using KuaforIsletmeYonetim.Models;

namespace KuaforIsletmeYonetim.Controllers
{
    public class SalonController : Controller
    {
        private readonly KuaforContext _context;

        public SalonController(KuaforContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salonlar?.Add(salon);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salon);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var salonlar = _context.Salonlar?.ToList();
            return View(salonlar);
        }

        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            var salon = _context.Salonlar?.FirstOrDefault(s => s.Id == id);
            if (salon == null)
            {
                return NotFound();
            }
            return View(salon);
        }

        [HttpPost]
        public IActionResult Duzenle(Salon salon)
        {
            if (ModelState.IsValid)
            {
                _context.Salonlar?.Update(salon);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salon);
        }

        [HttpGet]
        public IActionResult Sil(int id)
        {
            var salon = _context.Salonlar?.FirstOrDefault(s => s.Id == id);
            if (salon == null)
            {
                return NotFound();
            }

            _context.Salonlar?.Remove(salon);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
