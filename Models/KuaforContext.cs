using KuaforYonetim.Models;
using Microsoft.EntityFrameworkCore;

namespace KuaforIsletmeYonetim.Models
{
    public class KuaforContext : DbContext
    {
        public KuaforContext(DbContextOptions<KuaforContext> options) : base(options) { }

        public DbSet<Salon>? Salonlar { get; set; }
        public DbSet<Islem>? Islemler { get; set; }
        public DbSet<Calisan>? Calisanlar { get; set; }
        public DbSet<Randevu>? Randevular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Randevu ve Çalışan ilişkisi
            modelBuilder.Entity<Randevu>()
                .HasOne(r => r.Calisan)
                .WithMany()
                .HasForeignKey(r => r.CalisanId)
                .OnDelete(DeleteBehavior.Restrict);

            // Salon ve Çalışan ilişkisi
            modelBuilder.Entity<Calisan>()
                .HasOne(c => c.Salon)
                .WithMany(s => s.Calisanlar)
                .HasForeignKey(c => c.SalonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Varsayılan veriler
            modelBuilder.Entity<Salon>().HasData(
                new Salon { Id = 1, Ad = "Kuaför A", Adres = "Adres A", Telefon = "0123456789" }
            );

            modelBuilder.Entity<Calisan>().HasData(
                new Calisan { Id = 1, Ad = "Ahmet Yılmaz", SalonId = 1 },
                new Calisan { Id = 2, Ad = "Ayşe Demir", SalonId = 1 }
            );
        }
    }
}
