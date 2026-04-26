using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Data.Entities;

namespace OrderService.Data.Configurations;

public class OrderItemsConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(o => o.Id);

        builder
            .HasOne(o => o.Order)
            .WithMany(o => o.OrderItems)
            .HasForeignKey(o => o.OrderId);

        builder.HasData(
            new OrderItem
            {
                Id = Guid.Parse("d1111111-1111-1111-1111-111111111111"),
                OrderId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductId = Guid.Parse("c1111111-1111-1111-1111-111111111111"),
                ProductName = "Пицца Маргарита",
                Price = 500.00m,
                Quantity = 2
            },
            new OrderItem
            {
                Id = Guid.Parse("d2222222-2222-2222-2222-222222222222"),
                OrderId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                ProductId = Guid.Parse("c2222222-2222-2222-2222-222222222222"),
                ProductName = "Кола 0.5",
                Price = 100.00m,
                Quantity = 5
            },
            new OrderItem
            {
                Id = Guid.Parse("d3333333-3333-3333-3333-333333333333"),
                OrderId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                ProductId = Guid.Parse("c3333333-3333-3333-3333-333333333333"),
                ProductName = "Бургер Классик",
                Price = 600.00m,
                Quantity = 1
            }
        );
    }
}