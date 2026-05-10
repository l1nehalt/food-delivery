namespace Contracts.Dtos;

public class ConfirmedItemDto
{
    public Guid ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public int Quantity { get; set; }
}