using KitchenService.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace KitchenService.Controllers;

[ApiController]
[Route("/api/kitchen")]
public class KitchenController(IKitchenService kitchenService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await kitchenService.GetAll();
        
        return Ok(result);
    }
}