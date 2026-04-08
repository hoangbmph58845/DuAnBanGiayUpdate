using Microsoft.EntityFrameworkCore;
using KtraLab.DB.Model;

var builder = WebApplication.CreateBuilder(args);

// ĐĂNG KÝ DỊCH VỤ DB CONTEXT Ở ĐÂY (project Web)
builder.Services.AddDbContext<DbContextApp>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();   // nếu dùng MVC
// builder.Services.AddControllers();         // nếu dùng API thuần

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();