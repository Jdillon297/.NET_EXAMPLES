using IdentityApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Runtime.CompilerServices;

namespace IdentityApi.Data;

public static class Seed
{
    public static async Task Initialize(IServiceProvider service)
    {
        await service.GetRequiredService<DataContext>().Database.MigrateAsync();
        await SeedUsers(service);
    }


    private static async Task SeedUsers(IServiceProvider service)
    {
        const string defaultPassword = "Password123!";
        const string adminPassword = "HelloWorld123!";
        var userManager = service.GetRequiredService<UserManager<User>>();
        var roleManager = service.GetRequiredService<RoleManager<Role>>();

        if (userManager.Users.Any())
        {
            return;
        }

        var adminUser = new User
        {
            UserName = "Jacob"
        };

        var user = new User
        {
            UserName = "Bob"
        };

        var adminRole = new Role
        {
            Name = "Admin",
            Description = "Can create books and add to site."
        };

        var role = new Role
        {
            Name = "User",
            Description ="Can add books to cart to buy."
        };

        await roleManager.CreateAsync(role);
        await roleManager.CreateAsync(adminRole);

        await userManager.CreateAsync(adminUser, adminPassword);
        await userManager.CreateAsync(user,defaultPassword);

        await userManager.AddToRoleAsync(adminUser, adminRole.Name);
        await userManager.AddToRoleAsync(user, role.Name);




        await service.GetRequiredService<DataContext>().SaveChangesAsync();

    }

}
