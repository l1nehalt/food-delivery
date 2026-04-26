using CatalogService.Data.Configurations;
using CatalogService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data;

public class CatalogDbContext(DbContextOptions<CatalogDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Restaurant> Restaurants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
        modelBuilder.ApplyConfiguration(new ProductsConfiguration());
        modelBuilder.ApplyConfiguration(new RestaurantsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}