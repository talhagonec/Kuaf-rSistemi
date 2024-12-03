using System.Collections.Generic;

namespace KuaforIsletmeYonetim.Models
{
    public class Salon
    {
        public int Id { get; set; } // Benzersiz kimlik (Primary Key)
        public string Ad { get; set; } = string.Empty; // Salon adı
        public string Adres { get; set; } = string.Empty; // Salon adresi
        public string Telefon { get; set; } = string.Empty; // Salon telefon numarası

        // Çalışanlar ile ilişki
        public ICollection<Calisan> Calisanlar { get; set; } = new List<Calisan>(); // Bu salonun çalışanları
    }
}
