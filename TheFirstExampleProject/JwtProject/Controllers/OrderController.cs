using JwtProject.Interfaces;
using JwtProject.Queries;
using JwtProject.Security.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

[ApiController]
public class OrderController
{
    private readonly IOrderService _service;

    public OrderController(IOrderService service) => _service = service;

    [HttpGet("order/all")]
    [Role([1])]
    public async Task<IActionResult> GetAllOrders() => await _service.GetAllOrdersAsync();

    [HttpPost("order/createOrder")]
    [Role([1])]
    public async Task<IActionResult> CreateOrder([FromBody] OrderQuery reader, [FromHeader] string authorization) =>
        await _service.CreateOrderAsync(reader, authorization);
    
    [HttpPut("order/changeStatus")]
    [Role([1])]
    public async Task<IActionResult> ChangeYourMindSet1(int id, string status) => await _service.ChangeYourMindSet1(id, status);
    
    [HttpPut("order/changeOrderType")]
    [Role([1])]
    public async Task<IActionResult> ChangeYourMindSet2(int id, string deliveryType) => await _service.ChangeYourMindSet2(id, deliveryType);
}