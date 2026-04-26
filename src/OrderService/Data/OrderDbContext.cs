using Microsoft.EntityFrameworkCore;
using OrderService.Data.Configurations;
using OrderService.Data.Entities;

namespace OrderService.Data;

public class OrderDbContext(DbContextOptions<OrderDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrdersConfiguration());
        modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}