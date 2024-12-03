namespace KuaforIsletmeYonetim.Models
{
    public class Calisan
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;

        // Salon ile ilişki
        public int SalonId { get; set; } // Foreign Key
        public Salon? Salon { get; set; } // Navigation Property
    }
}
