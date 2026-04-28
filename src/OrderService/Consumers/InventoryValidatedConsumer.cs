using Contracts.Catalog;
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

        order.Status = allAvailableItems
            ? OrderStatus.Confirmed
            : OrderStatus.Cancelled;

        await ordersService.Update(order);
    }
}