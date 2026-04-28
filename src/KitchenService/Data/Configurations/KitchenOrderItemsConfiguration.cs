using KitchenService.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KitchenService.Data.Configurations;

public class KitchenOrderItemsConfiguration : IEntityTypeConfiguration<KitchenOrderItem>
{
    public void Configure(EntityTypeBuilder<KitchenOrderItem> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder
            .HasOne(x => x.KitchenOrder)
            .WithMany(x => x.KitchenOrderItems)
            .HasForeignKey(x => x.KitchenOrderId);
    }
}