using CatalogService.Abstractions;
using CatalogService.Services;
using Contracts.Catalog;
using Contracts.Dtos;
using Contracts.Orders;
using MassTransit;

namespace CatalogService.Consumers;

public class OrderCreatedConsumer(IProductsService productsService) : IConsumer<OrderCreatedEvent>
{
    public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
    {
        var ids = context.Message.Products
            .Select(x => x.ProductId)
            .ToList();

        var availableProducts = await productsService.CheckProductsAvailability(ids);

        var productDtos = availableProducts
            .Select(x => new ProductItemDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                IsAvailable = x.IsAvailable
            })
            .ToList();

        await context.Publish(new InventoryValidatedEvent
        {
            OrderId = context.Message.OrderId,
            AvailableProducts = productDtos
        });
    }
}