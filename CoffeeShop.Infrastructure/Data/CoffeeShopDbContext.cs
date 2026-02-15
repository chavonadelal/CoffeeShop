using CoffeeShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.Infrastructure.Data;

/// <summary>
/// EF Core session with the database. One instance per HTTP request when registered as Scoped.
/// </summary>
public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.ToTable("Products");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).HasMaxLength(200);
            entity.Property(e => e.Price).HasPrecision(18, 2);
            entity.HasData(
                new Product { Id = Guid.Parse("11111111-1111-1111-1111-111111111111"), Name = "Espresso", Price = 2.50m },
                new Product { Id = Guid.Parse("22222222-2222-2222-2222-222222222222"), Name = "Latte", Price = 3.50m },
                new Product { Id = Guid.Parse("33333333-3333-3333-3333-333333333333"), Name = "Cappuccino", Price = 3.00m }
            );
        });
    }
}
