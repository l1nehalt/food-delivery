using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Data.Entities;

namespace OrderService.Data.Configurations;

public class OrdersConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasMany(o => o.OrderItems)
            .WithOne(i => i.Order)
            .HasForeignKey(i => i.OrderId);

        var orderId1 = Guid.Parse("11111111-1111-1111-1111-111111111111");
        var orderId2 = Guid.Parse("22222222-2222-2222-2222-222222222222");

        builder.HasData(
            new Order
            {
                Id = orderId1,
                UserId = Guid.Parse("aaaaaaa1-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                Status = OrderStatus.Confirmed,
                TotalPrice = 1500.00m,
                CreatedAt = DateTime.SpecifyKind(new DateTime(2026, 4, 25), DateTimeKind.Utc)
            },
            new Order
            {
                Id = orderId2,
                UserId = Guid.Parse("bbbbbbb2-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                Status = OrderStatus.Pending,
                TotalPrice = 600.00m,
                CreatedAt = DateTime.SpecifyKind(new DateTime(2026, 4, 25), DateTimeKind.Utc)
            }
        );
    }
}