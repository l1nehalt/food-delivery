namespace CatalogService.Data.Entities;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public Guid CategoryId { get; set; }

    public Guid RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }

    public Category? Category { get; set; }
}