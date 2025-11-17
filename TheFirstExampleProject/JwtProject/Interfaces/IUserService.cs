using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Interfaces;

public interface IUserService
{
    Task<IActionResult> GetAllUsersAsync(int id_role);
    Task<IActionResult> CreateUserAsync(int id_role, UserLoginQuery query);
    Task<IActionResult> UpdateUserAsync(UserLoginQuery query, int id);
    Task<IActionResult> DeleteUserAsync(int id);
}