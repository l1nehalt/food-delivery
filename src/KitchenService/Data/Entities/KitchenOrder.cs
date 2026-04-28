namespace KitchenService.Data.Entities;

public class KitchenOrder
{
    public Guid Id { get; set; }

    public Guid OrderId { get; set; }

    public KitchenStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<KitchenOrderItem> KitchenOrderItems { get; set; } = [];
}