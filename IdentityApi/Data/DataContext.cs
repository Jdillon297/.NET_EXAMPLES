using IdentityApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityApi.Data;

public class DataContext : IdentityDbContext<User,Role,int>
{
   public DbSet<Book>Books { get; set; }
    public DbSet<Cart> Carts {  get; set; }

    public DbSet<CartBook> CartBooks { get; set; } 
    public DataContext(DbContextOptions<DataContext> options)
       : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
        .HasOne(u => u.Cart)
        .WithOne(c => c.User)
        .HasForeignKey<Cart>(c => c.UserId)
        .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<CartBook>()
           .HasKey(cb => new { cb.CartId, cb.BookId });

        builder.Entity<CartBook>()
            .HasOne(cb => cb.Cart)
            .WithMany(c => c.CartBooks)
            .HasForeignKey(cb => cb.CartId);

        builder.Entity<CartBook>()
            .HasOne(cb => cb.Book)
            .WithMany(b => b.CartBooks)
            .HasForeignKey(cb => cb.BookId);

        base.OnModelCreating(builder);

       

    }
}
