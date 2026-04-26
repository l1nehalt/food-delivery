using CatalogService.Dtos;

namespace CatalogService.Abstractions;

public interface IProductsService
{
    Task<List<ProductDto>> GetProducts();

    Task<List<ProductDto>> CheckProductsAvailability(List<Guid> guids);
}