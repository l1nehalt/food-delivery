using CatalogService.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers;

[ApiController]
[Route("/api/products")]
public class ProductsController(IProductsService productsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await productsService.GetAll();

        return Ok(products);
    }

    [HttpPost("validate")]
    public async Task<IActionResult> Validate([FromBody] List<Guid> guids)
    {
        var products = await productsService.CheckAvailability(guids);

        return Ok(products);
    }
}