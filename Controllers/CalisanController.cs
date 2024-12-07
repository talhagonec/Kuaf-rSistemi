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

        // �al��anlar�n listelendi�i sayfa
        public IActionResult Index()
        {
            var calisanlar = _context.Calisanlar?.Include(c => c.Salon).ToList() ?? new List<Calisan>();
            return View(calisanlar);
        }

        // �al��an detaylar�n�n g�r�nt�lendi�i sayfa
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound("�al��an ID'si belirtilmedi.");
            }

            var calisan = _context.Calisanlar?.Include(c => c.Salon).FirstOrDefault(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound("�al��an bulunamad�.");
            }

            return View(calisan);
        }

        // Yeni �al��an ekleme formu
        public IActionResult Create()
        {
            ViewBag.SalonId = new SelectList(_context.Salonlar ?? Enumerable.Empty<Salon>(), "Id", "Isim");
            return View();
        }

        // Yeni �al��an�n veritaban�na kaydedilmesi
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
                try
                {
                    _context.Calisanlar?.Add(calisan);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", $"Bir hata olu�tu: {ex.InnerException?.Message ?? ex.Message}");
                }
            }

            ViewBag.SalonId = new SelectList(_context.Salonlar ?? Enumerable.Empty<Salon>(), "Id", "Isim", calisan.SalonId);
            return View(calisan);
        }

        // �al��an d�zenleme formu
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound("�al��an ID'si belirtilmedi.");
            }

            var calisan = _context.Calisanlar?.Find(id);
            if (calisan == null)
            {
                return NotFound("�al��an bulunamad�.");
            }

            ViewBag.SalonId = new SelectList(_context.Salonlar ?? Enumerable.Empty<Salon>(), "Id", "Isim", calisan.SalonId);
            return View(calisan);
        }

        // D�zenlenen �al��an�n kaydedilmesi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Calisan calisan)
        {
            if (id != calisan.Id)
            {
                return NotFound("�al��an ID'si uyu�muyor.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calisan);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", $"Bir hata olu�tu: {ex.InnerException?.Message ?? ex.Message}");
                }
            }

            ViewBag.SalonId = new SelectList(_context.Salonlar ?? Enumerable.Empty<Salon>(), "Id", "Isim", calisan.SalonId);
            return View(calisan);
        }

        // �al��an silme onay sayfas�
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("�al��an ID'si belirtilmedi.");
            }

            var calisan = _context.Calisanlar?.Include(c => c.Salon).FirstOrDefault(m => m.Id == id);
            if (calisan == null)
            {
                return NotFound("�al��an bulunamad�.");
            }

            return View(calisan);
        }

        // �al��an silme i�lemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (_context.Calisanlar == null)
            {
                return Problem("Veritaban�nda 'Calisanlar' tablosu bulunamad�.");
            }

            var calisan = _context.Calisanlar.Find(id);
            if (calisan != null)
            {
                try
                {
                    _context.Calisanlar.Remove(calisan);
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    ModelState.AddModelError("", $"Silme i�leminde bir hata olu�tu: {ex.InnerException?.Message ?? ex.Message}");
                    return RedirectToAction(nameof(Delete), new { id });
                }
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
