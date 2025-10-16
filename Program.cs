using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Data;
using MVC_CRUD.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Connection string (z appsettings.json lub bezpośrednio)
var connString = builder.Configuration.GetConnectionString("MySql");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connString, ServerVersion.AutoDetect(connString))
);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireDigit = false;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();


// 🔹 Add MVC controllers + views
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

await SeedService.SeedDatabase(app.Services);

// 🔹 Middleware i routing
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
