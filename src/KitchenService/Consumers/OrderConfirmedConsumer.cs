using Contracts.Orders;
using KitchenService.Abstractions;
using KitchenService.Dtos;
using MassTransit;

namespace KitchenService.Consumers;

public class OrderConfirmedConsumer(IKitchenService kitchenService) : IConsumer<OrderConfirmedEvent>
{
    public async Task Consume(ConsumeContext<OrderConfirmedEvent> context)
    {
        await kitchenService.Create(new KitchenOrderCreationDto
        {
            OrderId = context.Message.OrderId,
            KitchenOrderItems = context.Message.ConfirmedItems
                .Select(x => new KitchenOrderItemDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity
                }).ToList()
        });
    }
}