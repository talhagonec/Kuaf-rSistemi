using Microsoft.AspNetCore.Mvc;
using KuaforIsletmeYonetim.Models;

namespace KuaforIsletmeYonetim.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalonApiController : ControllerBase
    {
        private readonly KuaforContext _context;

        public SalonApiController(KuaforContext context)
        {
            _context = context;
        }

        // Tüm salonları listeleyen endpoint
        [HttpGet]
        public IActionResult GetSalonlar()
        {
            if (_context.Salonlar == null)
            {
                return NotFound("Veritabanında salon bulunamadı.");
            }

            var salonlar = _context.Salonlar.ToList();
            return Ok(salonlar);
        }

        // Yeni Test Endpoint
        [HttpGet("Test")]
        public IActionResult TestEndpoint()
        {
            return Ok("API çalışıyor!");
        }
    }
}
