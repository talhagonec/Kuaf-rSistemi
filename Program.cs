using Microsoft.EntityFrameworkCore;
using KuaforIsletmeYonetim.Models;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL ba�lant�s�n� ekleyin
builder.Services.AddDbContext<KuaforContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller ve View hizmetlerini ekleyin
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware yap�land�rmas�
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // Hata sayfas� geli�tirme ortam�nda g�r�n�r
}

app.UseHttpsRedirection(); // HTTP'den HTTPS'ye y�nlendirme
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization(); // Yetkilendirme eklenmesi (opsiyonel)

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
