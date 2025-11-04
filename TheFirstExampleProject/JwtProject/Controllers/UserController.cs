using JwtProject.Interfaces;
using JwtProject.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

[ApiController]
public class UserController
{
    private readonly IShopService _service;
    public UserController(IShopService service) => _service = service;
    
    [AllowAnonymous]
    [HttpPost("user/authorization")]
    public async Task<IActionResult> Authorization([FromBody]LoginQuery reader) => await _service.AuthorizationUserAsync(reader);
    
    [HttpGet("user/profile")]
    public async Task<IActionResult> GetProfile([FromHeader]string Authorization) => await _service.GetProfileAsync(Authorization);
    
    [HttpPost("user/profile")]
    public async Task<IActionResult> UpdateProfile([FromHeader]string Authorization, UserLoginQuery reader) => await _service.UpdateProfileAsync(Authorization, reader);
}