using Contracts.Catalog;
using Contracts.Dtos;
using Contracts.Orders;
using MassTransit;
using OrderService.Abstractions;
using OrderService.Data.Entities;

namespace OrderService.Consumers;

public class InventoryValidatedConsumer(IOrdersService ordersService) : IConsumer<InventoryValidatedEvent>
{
    public async Task Consume(ConsumeContext<InventoryValidatedEvent> context)
    {
        var order = await ordersService.GetById(context.Message.OrderId);

        var allAvailableItems = order.OrderItems
            .All(x => context.Message.AvailableProducts
                .Any(p => p.Id == x.ProductId && p.IsAvailable));

        if (allAvailableItems)
        {
            order.Status = OrderStatus.Confirmed;

            await context.Publish(new OrderConfirmedEvent
            {
                OrderId = order.Id,
                ConfirmedItems = order.OrderItems.Select(x => new ConfirmedItemDto
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Quantity = x.Quantity
                }).ToList()
            });
        }
        else
        {
            order.Status = OrderStatus.Cancelled;
        }

        await ordersService.Update(order);
    }
}