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
        var userManager = service.GetRequiredService<UserManager<User>>();

        if (userManager.Users.Any())
        {
            return;
        }

        var user = new User
        {
            UserName = "Jacob"
        };

        await userManager.CreateAsync(user,"Password123!");

        await service.GetRequiredService<DataContext>().SaveChangesAsync();

    }

}
