using KuaforDbSistemi.Data;
using KuaforDbSistemi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KuaforDbSistemi.Controllers
{
    public class CalisanController : Controller
    {
        private readonly KuaforContext _context;

        public CalisanController(KuaforContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var calisanlar = _context.Calisanlar
                .Include(c => c.Salon)
                .ToList();
            return View(calisanlar);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = _context.Calisanlar
                .Include(c => c.Salon)
                .FirstOrDefault(m => m.Id == id);

            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        public IActionResult Create()
        {
            ViewBag.SalonId = new SelectList(_context.Salonlar, "Id", "Isim");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Calisan calisan)
        {
            if (_context.Salonlar == null || !_context.Salonlar.Any(s => s.Id == calisan.SalonId))
            {
                ModelState.AddModelError("SalonId", "Ge�ersiz bir salon se�ildi.");
            }

            if (ModelState.IsValid)
            {
                _context.Calisanlar.Add(calisan);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.SalonId = new SelectList(_context.Salonlar, "Id", "Isim", calisan.SalonId);
            return View(calisan);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = _context.Calisanlar.Find(id);
            if (calisan == null)
            {
                return NotFound();
            }

            ViewBag.SalonId = new SelectList(_context.Salonlar, "Id", "Isim", calisan.SalonId);
            return View(calisan);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Calisan calisan)
        {
            if (id != calisan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calisan);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("", "Bir hata olu�tu. L�tfen tekrar deneyiniz.");
                }
            }

            ViewBag.SalonId = new SelectList(_context.Salonlar, "Id", "Isim", calisan.SalonId);
            return View(calisan);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calisan = _context.Calisanlar
                .Include(c => c.Salon)
                .FirstOrDefault(m => m.Id == id);

            if (calisan == null)
            {
                return NotFound();
            }

            return View(calisan);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var calisan = _context.Calisanlar
                .Include(c => c.Randevular)
                .FirstOrDefault(c => c.Id == id);

            if (calisan != null)
            {
                if (calisan.Randevular.Any())
                {
                    ModelState.AddModelError("", "Bu �al��an mevcut randevularla ili�kili oldu�u i�in silinemez.");
                    return View("Delete", calisan);
                }

                _context.Calisanlar.Remove(calisan);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
