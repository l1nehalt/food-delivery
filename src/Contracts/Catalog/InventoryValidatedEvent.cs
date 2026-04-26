using Contracts.Dtos;

namespace Contracts.Catalog;

public class InventoryValidatedEvent
{
    public Guid OrderId { get; set; }

    public List<ProductItemDto> AvailableProducts { get; set; } = [];
}