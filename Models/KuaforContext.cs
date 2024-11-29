using KuaforIsletmeYonetim.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KuaforYonetim.Models
{
    public class KuaforContext : DbContext
    {
        public KuaforContext(DbContextOptions<KuaforContext> options) : base(options) { }

        public DbSet<Salon>? Salonlar { get; set; }
        public DbSet<Islem>? Islemler { get; set; }
        public DbSet<Calisan>? Calisanlar { get; set; }
    }
}
