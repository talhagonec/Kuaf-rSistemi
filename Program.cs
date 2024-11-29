using Microsoft.EntityFrameworkCore;
using KuaforIsletmeYonetim.Models;
using KuaforYonetim.Models;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL baðlantýsýný ekleyin
builder.Services.AddDbContext<KuaforContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller hizmetlerini ekleyin
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware yapýlandýrmasý
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=SalonView}/{action=Index}/{id?}"); // Varsayýlan rota
});

app.Run();
