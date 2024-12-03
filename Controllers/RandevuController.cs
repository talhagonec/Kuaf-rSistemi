using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using KuaforIsletmeYonetim.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace KuaforIsletmeYonetim.Controllers
{
    public class RandevuController : Controller
    {
        private readonly KuaforContext _context;

        public RandevuController(KuaforContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Tüm randevuların listesi
        public IActionResult Index()
        {
            try
            {
                // Null kontrolü
                var randevular = _context.Randevular?
                    .Include(r => r.Calisan) // Çalışan ile ilişkiyi dahil et
                    .ToList() ?? new List<Randevu>();

                return View(randevular);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                TempData["Hata"] = "Randevular listelenirken bir hata oluştu.";
                return View(new List<Randevu>());
            }
        }

        // Yeni randevu oluşturma sayfası
        public IActionResult Yeni()
        {
            try
            {
                // Null kontrolü
                var calisanlar = _context.Calisanlar?.ToList() ?? new List<Calisan>();

                if (!calisanlar.Any())
                {
                    TempData["Hata"] = "Çalışan bulunamadı. Önce çalışan ekleyin.";
                    return RedirectToAction("Index");
                }

                ViewBag.Calisanlar = calisanlar;
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                TempData["Hata"] = "Yeni randevu oluşturma ekranı yüklenemedi.";
                return RedirectToAction("Index");
            }
        }

        // Yeni randevu kaydetme işlemi
        [HttpPost]
        public IActionResult Yeni(Randevu randevu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_context.Randevular != null) // Null kontrolü
                    {
                        _context.Randevular.Add(randevu);
                        _context.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata: {ex.Message}");
                    ModelState.AddModelError(string.Empty, "Randevu kaydedilirken bir hata oluştu.");
                }
            }

            var calisanlar = _context.Calisanlar?.ToList() ?? new List<Calisan>();
            ViewBag.Calisanlar = calisanlar;
            return View(randevu);
        }
    }
}
