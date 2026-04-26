using Contracts.Dtos;

namespace Contracts.Orders;

public class OrderCreatedEvent
{
    public Guid OrderId { get; set; }

    public List<OrderCreatedItem> Products { get; set; } = [];
}