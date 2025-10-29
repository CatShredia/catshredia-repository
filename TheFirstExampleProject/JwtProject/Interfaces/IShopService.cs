using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Interfaces;

public interface IShopService 
{
    Task<IActionResult> GetAllEmployeesAsync();
    Task<IActionResult> CreateEmployeeAsync(UserLoginQuery query);
    Task<IActionResult> UpdateEmployeeAsync(UserLoginQuery query, int id);
    Task<IActionResult> DeleteEmployeeAsync(int id);
}