using LibraryAPI.CustomAttributes;
using LibraryAPI.Interfaces;
using LibraryAPI.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController
{
    private readonly ILibraryService _service;
    public UsersController(ILibraryService service) => _service = service;

    [HttpGet]
    [RoleAuthorized(1)]
    public async Task<IActionResult> GetAll() => await _service.GetAllUsersAsync();

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id) => await _service.GetUserByIdAsync(id);

    [HttpPost]
    [RoleAuthorized(1)]
    public async Task<IActionResult> Create([FromBody]UserQuery reader) => await _service.CreateNewUserAndLoginAsync(reader);

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UserQuery reader) =>
        await _service.EditUserAndLoginAsync(id, reader);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) => await _service.DeleteUserAndLoginAsync(id);
}