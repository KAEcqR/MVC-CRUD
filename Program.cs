using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Connection string (z appsettings.json lub bezpośrednio)
var connString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connString, ServerVersion.AutoDetect(connString))
);

// 🔹 Add MVC controllers + views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🔹 Middleware i routing
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
