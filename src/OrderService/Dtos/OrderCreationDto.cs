namespace OrderService.Dtos;

public class OrderCreationDto
{
    public Guid UserId { get; set; }

    public List<OrderItemDto> OrderItems { get; set; } = [];
}