using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC_CRUD.Models;
using MVC_CRUD.Data;

namespace MVC_CRUD.Data;

public class SeedService
{
    public static async Task SeedDatabase(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var roleMenager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<SeedService>>();

        try
        {
            logger.LogInformation("Ensuring database is created.");
            context.Database.EnsureCreated();

            // Seed roles
            await AddRoleAsync(roleMenager, "Admin");
            await AddRoleAsync(roleMenager, "User");

            logger.LogInformation("Seeding admin user.");
            var adminEmail = "admin@ticket.com";
            if(await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    NormalizedUserName = adminEmail.ToUpper(),
                    Email = adminEmail,
                    NormalizedEmail = adminEmail.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                    logger.LogInformation("Admin user created.");
                }
                
            }
            else
            {
                logger.LogInformation("Admin user already exists.");
            }
        }   
        catch (Exception ex)
        {
            logger.LogError(ex, "An error occurred creating the DB.");
        }


        await context.SaveChangesAsync();
        }

    private static async Task AddRoleAsync(RoleManager<IdentityRole> roleMenager, string roleName)
    {
        if (!await roleMenager.RoleExistsAsync(roleName))
        {
            var result = await roleMenager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new Exception($"Failed to create role '{roleName}': {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}
