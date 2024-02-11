using IdentityApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Data;

public class DataContext : IdentityDbContext<User,IdentityRole<int>,int>
{
    public DataContext(DbContextOptions<DataContext> options)
       : base(options)
    {
    }
}
