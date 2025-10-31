using JwtProject.Interfaces;
using JwtProject.Queries;
using JwtProject.Security.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

[ApiController]
public class OrderController
{
    private readonly IShopService _service;

    public OrderController(IShopService service) => _service = service;

    [HttpGet("order/all")]
    [Role([1])]
    public async Task<IActionResult> GetAllOrders() => await _service.GetAllOrdersAsync();

    [HttpPost("order/createOrder")]
    [Role([1])]
    public async Task<IActionResult> CreateOrder([FromBody] OrderQuery reader) =>
        await _service.CreateOrderAsync(reader);

    [HttpPut("order/cancelOrder")]
    [Role([1])]
    public async Task<IActionResult> CancelOrder(int id) => await _service.CancelOrderAsync(id);
    
    [HttpPut("order/changeYourMindSet")]
    [Role([1])]
    public async Task<IActionResult> ChangeYourMindSet(int id, [FromBody] OrderQuery reader) => await _service.ChangeYourMindSet(id, reader);
}