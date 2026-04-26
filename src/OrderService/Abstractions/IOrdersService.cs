using OrderService.Data.Entities;
using OrderService.Dtos;

namespace OrderService.Abstractions;

public interface IOrdersService
{
    Task Create(OrderCreationDto order);

    Task<Order?> GetById(Guid orderId);

    Task Update(Order order);
}