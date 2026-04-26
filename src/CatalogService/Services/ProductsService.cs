using CatalogService.Abstractions;
using CatalogService.Data;
using CatalogService.Dtos;
using CatalogService.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Services;

public class ProductsService(CatalogDbContext dbContext) : IProductsService
{
    public async Task<List<ProductDto>> GetProducts()
    {
        var products = await dbContext.Products
            .AsNoTracking()
            .ToListAsync();

        return products
            .Select(x => x.ToDto())
            .ToList();
    }

    public async Task<List<ProductDto>> CheckProductsAvailability(List<Guid> guids)
    {
        var products = await dbContext.Products
            .AsNoTracking()
            .Where(x => guids.Contains(x.Id) && x.IsAvailable == true)
            .ToListAsync();

        return products
            .Select(x => x.ToDto())
            .ToList();
    }
}