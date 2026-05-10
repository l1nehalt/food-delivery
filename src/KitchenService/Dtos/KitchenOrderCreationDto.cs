using KitchenService.Data.Entities;

namespace KitchenService.Dtos;

public class KitchenOrderCreationDto
{
    public Guid OrderId { get; set; }

    public KitchenStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public List<KitchenOrderItemDto> KitchenOrderItems { get; set; } = [];
}