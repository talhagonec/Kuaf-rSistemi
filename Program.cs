using Microsoft.EntityFrameworkCore;
using KuaforIsletmeYonetim.Models;
using KuaforYonetim.Models;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL ba�lant�s�n� ekleyin
builder.Services.AddDbContext<KuaforContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller hizmetlerini ekleyin
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware yap�land�rmas�
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=SalonView}/{action=Index}/{id?}"); // Varsay�lan rota
});

app.Run();
