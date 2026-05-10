using CatalogService.Dtos;

namespace CatalogService.Abstractions;

public interface IProductsService
{
    Task<List<ProductDto>> GetAll();

    Task<List<ProductDto>> CheckAvailability(List<Guid> guids);
}