using KitchenService.Abstractions;
using KitchenService.Data;
using KitchenService.Data.Entities;
using KitchenService.Dtos;
using Microsoft.EntityFrameworkCore;

namespace KitchenService.Services;

public class KitchenService(KitchenDbContext dbContext) : IKitchenService
{
    public async Task Create(KitchenOrderCreationDto kitchenOrderCreationDto)
    {
        var kitchenOrder = new KitchenOrder
        {
            OrderId = kitchenOrderCreationDto.OrderId,
            Status = KitchenStatus.Cooking,
            CreatedAt = DateTime.UtcNow,
            KitchenOrderItems = kitchenOrderCreationDto
                .KitchenOrderItems
                .Select(x => new KitchenOrderItem
                {
                    ProductId = x.ProductId,
                    ProductName = x.ProductName,
                    Comment = x.Comment,
                    Quantity = x.Quantity
                }).ToList()
        };

        await dbContext.KitchenOrders.AddAsync(kitchenOrder);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<KitchenOrderDto>> GetAll()
    {
        var kitchenOrders = await dbContext.KitchenOrders
            .Include(kitchenOrder => kitchenOrder.KitchenOrderItems)
            .ToListAsync();

        return kitchenOrders.Select(x => new KitchenOrderDto
        {
            KitchenOrderId = x.OrderId,
            KitchenOrderItems = x.KitchenOrderItems.Select(item => new KitchenOrderItemDto
            {
                ProductId = item.ProductId,
                ProductName = item.ProductName,
                Comment = item.Comment,
                Quantity = item.Quantity
            }).ToList()
        }).ToList();
    }
}