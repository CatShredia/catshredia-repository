using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;

namespace JwtProject.Interfaces;

public interface IAuthService
{
    Task<IActionResult> AuthorizationUserAsync(LoginQuery query);
    Task<IActionResult> GetProfileAsync(string Authorization);
    Task<IActionResult> UpdateProfileAsync(string Authorization, UserLoginQuery query);
}