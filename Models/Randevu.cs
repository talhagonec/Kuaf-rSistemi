using System;

namespace KuaforIsletmeYonetim.Models
{
    public class Randevu
    {
        public int Id { get; set; } // Benzersiz kimlik (Primary Key)

        public int CalisanId { get; set; } // Çalışan ID'si (Foreign Key)
        public Calisan Calisan { get; set; } = null!; // Çalışan ile ilişki

        public DateTime BaslangicSaati { get; set; } // Randevu başlangıç tarihi
        public DateTime BitisSaati { get; set; } // Randevu bitiş tarihi

        public string MusteriAdi { get; set; } = string.Empty; // Müşteri adı
        public string Islem { get; set; } = string.Empty; // Yapılacak işlem bilgisi
        public decimal Ucret { get; set; } // İşlem ücreti
    }
}
