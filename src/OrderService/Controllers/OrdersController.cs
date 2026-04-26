using Microsoft.AspNetCore.Mvc;
using OrderService.Abstractions;
using OrderService.Dtos;

namespace OrderService.Controllers;

[ApiController]
[Route("/api/orders")]
public class OrdersController(IOrdersService ordersService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(OrderCreationDto order)
    {
        await ordersService.Create(order);
        
        return Created("", order);
    }
}