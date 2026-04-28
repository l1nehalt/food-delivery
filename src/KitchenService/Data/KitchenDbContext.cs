using KitchenService.Data.Configurations;
using KitchenService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.Data;

public class KitchenDbContext(DbContextOptions<KitchenDbContext> options) : DbContext(options)
{
    public DbSet<KitchenOrder> KitchenOrders { get; set; }
    
    public DbSet<KitchenOrderItem> KitchenOrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new KitchenOrderItemsConfiguration());
        modelBuilder.ApplyConfiguration(new KitchenOrdersConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}

