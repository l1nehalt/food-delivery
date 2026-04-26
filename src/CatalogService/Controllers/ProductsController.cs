using CatalogService.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductsController(IProductsService productsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await productsService.GetProducts();

        return Ok(products);
    }

    [HttpPost("validate")]
    public async Task<IActionResult> Validate([FromBody] List<Guid> guids)
    {
        var products = await productsService.CheckProductsAvailability(guids);

        return Ok(products);
    }
}