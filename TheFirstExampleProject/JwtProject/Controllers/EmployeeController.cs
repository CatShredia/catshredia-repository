using JwtProject.Interfaces;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class EmployeeController
{
    private readonly IShopService _service;
    public EmployeeController(IShopService service) => _service = service;
    
    [HttpGet("employees/all")]
    public async Task<IActionResult> GetAllEmployees() => await _service.GetAllUsersAsync(2);
    [HttpPost("employees/create")]
    public async Task<IActionResult> CreateEmployee([FromBody]UserLoginQuery reader) => await _service.CreateUserAsync(2, reader);
    [HttpPut("employees/update")]
    public async Task<IActionResult> UpdateEmployee([FromBody]UserLoginQuery reader, int id) => await _service.UpdateUserAsync(reader, id);
    [HttpDelete("employees/delete")]
    public async Task<IActionResult> DeleteEmployee(int id) => await _service.DeleteUserAsync(id);

}