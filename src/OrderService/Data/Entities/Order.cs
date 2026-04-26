namespace OrderService.Data.Entities;

public class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public OrderStatus Status { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<OrderItem> OrderItems { get; set; } = [];
}