using Contracts.Dtos;
using Contracts.Orders;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OrderService.Abstractions;
using OrderService.Data;
using OrderService.Data.Entities;
using OrderService.Dtos;

namespace OrderService.Services;

public class OrdersService(OrderDbContext dbContext, IPublishEndpoint publishEndpoint) : IOrdersService
{
    public async Task Create(OrderCreationDto orderCreationDto)
    {
        var order = new Order
        {
            UserId = orderCreationDto.UserId,
            Status = OrderStatus.Pending,
            CreatedAt = DateTime.UtcNow,
            TotalPrice = orderCreationDto.OrderItems.Sum(o => o.Price * o.Quantity),
            OrderItems = orderCreationDto.OrderItems.Select(x => new OrderItem
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                Quantity = x.Quantity
            }).ToList()
        };

        await dbContext.AddAsync(order);
        await dbContext.SaveChangesAsync();

        var eventMessage = new OrderCreatedEvent
        {
            OrderId = order.Id,
            Products = order.OrderItems.Select(x => new OrderCreatedItem
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList()
        };

        await publishEndpoint.Publish(eventMessage);
    }

    public async Task<Order?> GetById(Guid orderId)
    {
        var order = await dbContext.Orders
            .Include(x => x.OrderItems)
            .FirstOrDefaultAsync(x => x.Id == orderId);

        return order;
    }

    public async Task Update(Order order)
    {
        dbContext.Update(order);
        await dbContext.SaveChangesAsync();
    }
}