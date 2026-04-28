namespace KitchenService.Data.Entities;

public class KitchenOrderItem
{
    public Guid Id { get; set; }
    
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public string Comment { get; set; } = string.Empty;
    
    public Guid KitchenOrderId { get; set; }
    
    public KitchenOrder? KitchenOrder { get; set; }
}