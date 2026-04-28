using KitchenService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenService.Data.Configurations;

public class KitchenOrdersConfiguration : IEntityTypeConfiguration<KitchenOrder>
{
    public void Configure(EntityTypeBuilder<KitchenOrder> builder)
    {
        builder.HasKey(k => k.Id);
        
        builder
            .HasMany(x => x.KitchenOrderItems)
            .WithOne(x => x.KitchenOrder)
            .HasForeignKey(x => x.KitchenOrderId);
    }
}