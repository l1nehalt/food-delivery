namespace CatalogService.Data.Entities;

public class Category
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public Guid RestaurantId { get; set; }

    public Restaurant? Restaurant { get; set; }
}