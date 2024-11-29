namespace KuaforYonetim.Models
{
    public class Salon
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Tur { get; set; } // Kadın, Erkek, Ortak
        public string? CalismaSaatleri { get; set; }
    }
}
