namespace Contracts.Dtos;

public class OrderCreatedItem
{
    public Guid ProductId { get; set; }

    public int Quantity { get; set; }
}