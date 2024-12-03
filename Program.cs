using Microsoft.EntityFrameworkCore;
using KuaforIsletmeYonetim.Models;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL baðlantýsýný ekleyin
builder.Services.AddDbContext<KuaforContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller ve View hizmetlerini ekleyin
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware yapýlandýrmasý
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // Hata sayfasý geliþtirme ortamýnda görünür
}

app.UseHttpsRedirection(); // HTTP'den HTTPS'ye yönlendirme
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
