namespace CatalogService.Data.Entities;

public class Restaurant
{
    public List<Category> Categories = [];

    public List<Product> Products = [];
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Address { get; set; } = string.Empty;

    public bool IsActive { get; set; }
}