using JwtProject.Interfaces;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class UserController
{
    private readonly IShopService _service;
    public UserController(IShopService service) => _service = service;
    
    [HttpPost("user/authorization")]
    public async Task<IActionResult> Authorization([FromBody]LoginQuery reader) => await _service.AuthorizationUserAsync(reader);
}