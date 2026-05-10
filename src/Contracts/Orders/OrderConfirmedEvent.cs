using Contracts.Dtos;

namespace Contracts.Orders;

public class OrderConfirmedEvent
{
    public Guid OrderId { get; set; }

    public List<ConfirmedItemDto> ConfirmedItems { get; set; } = [];
}