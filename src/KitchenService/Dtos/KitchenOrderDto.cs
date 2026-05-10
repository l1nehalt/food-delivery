namespace KitchenService.Dtos;

public class KitchenOrderDto
{
    public Guid KitchenOrderId { get; set; }

    public List<KitchenOrderItemDto> KitchenOrderItems { get; set; } = [];
}