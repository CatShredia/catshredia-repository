using JwtProject.Interfaces;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class OrderController
{
    private readonly IShopService _service;
    public OrderController(IShopService service) => _service = service;
    
    [HttpGet("order/all")]
    public async Task<IActionResult> GetAllOrders() => await _service.GetAllOrdersAsync();
    
    [HttpPost("order/createOrder")]
    public async Task<IActionResult> CreateOrder([FromBody]OrderQuery reader) => await _service.CreateOrderAsync(reader);
    
    [HttpPut("order/cancelOrder")]
    public async Task<IActionResult> CancelOrder(int id) => await _service.CancelOrderAsync(id);

}