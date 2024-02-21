using IdentityApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Data;

public class DataContext : IdentityDbContext<User,IdentityRole<int>,int>
{
   public DbSet<Book>Books { get; set; }
    public DbSet<Cart> Carts {  get; set; }
    public DataContext(DbContextOptions<DataContext> options)
       : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

       

    }
}
