using JwtProject.Interfaces;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Controllers;

public class EmployeeController
{
    private readonly IShopService _service;
    public EmployeeController(IShopService service) => _service = service;
    
    [HttpGet("all")]
    public async Task<IActionResult> GetAllEmployees() => await _service.GetAllEmployeesAsync();
    [HttpPost("create")]
    public async Task<IActionResult> CreateEmployee([FromBody]UserLoginQuery reader) => await _service.CreateEmployeeAsync(reader);
    [HttpPut("update")]
    public async Task<IActionResult> UpdateEmployee([FromBody]UserLoginQuery reader, int id) => await _service.UpdateEmployeeAsync(reader, id);
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteEmployee(int id) => await _service.DeleteEmployeeAsync(id);

}