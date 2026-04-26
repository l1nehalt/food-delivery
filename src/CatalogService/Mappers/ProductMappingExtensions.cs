using CatalogService.Data.Entities;
using CatalogService.Dtos;

namespace CatalogService.Mappers;

public static class ProductMappingExtensions
{
    public static ProductDto ToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            IsAvailable = product.IsAvailable
        };
    }
}