using JwtProject.Interfaces;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class ShoppersController
{
    private readonly IShopService _service;
    public ShoppersController(IShopService service) => _service = service;
    
    [HttpGet("shoppers/all")]
    public async Task<IActionResult> GetAllEShoppers() => await _service.GetAllUsersAsync(3);
    [HttpPost("shoppers/create")]
    public async Task<IActionResult> CreateEShopper([FromBody]UserLoginQuery reader) => await _service.CreateUserAsync(3, reader);
    [HttpPut("shoppers/update")]
    public async Task<IActionResult> UpdateEShopper([FromBody]UserLoginQuery reader, int id) => await _service.UpdateUserAsync(reader, id);
    [HttpDelete("shoppers/delete")]
    public async Task<IActionResult> DeleteEShopper(int id) => await _service.DeleteUserAsync(id);
}