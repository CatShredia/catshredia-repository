using JwtProject.Interfaces;
using JwtProject.Queries;
using JwtProject.Security.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

[ApiController]
public class ShoppersController
{
    private readonly IUserService _service;
    public ShoppersController(IUserService service) => _service = service;

    [HttpGet("shoppers/all")]
    [Role([1, 2])]
    public async Task<IActionResult> GetAllEShoppers() => await _service.GetAllUsersAsync(3);

    [HttpPost("shoppers/create")]
    [Role([1, 2])]
    public async Task<IActionResult> CreateShopper([FromBody] UserLoginQuery reader) =>
        await _service.CreateUserAsync(3, reader);

    [HttpPut("shoppers/update")]
    [Role([1, 2])]
    public async Task<IActionResult> UpdateEShopper([FromBody] UserLoginQuery reader, int id) =>
        await _service.UpdateUserAsync(reader, id);

    [HttpDelete("shoppers/delete")]
    [Role([1, 2])]
    public async Task<IActionResult> DeleteEShopper(int id) => await _service.DeleteUserAsync(id);
}