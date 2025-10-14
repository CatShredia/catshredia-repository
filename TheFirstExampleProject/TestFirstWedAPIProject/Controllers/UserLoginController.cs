using Microsoft.AspNetCore.Mvc;
using TestFirstWedAPIProject.Interfaces;

namespace TestFirstWedAPIProject.Controllers;

public class UserLoginController
{
    private readonly IUsersLoginsService _usersLoginsService;

    public UserLoginController(IUsersLoginsService usersLoginsService)
    {
        _usersLoginsService = usersLoginsService;
    }

    [HttpGet]
    [Route("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        return await _usersLoginsService.GetAllUsersAsync();
    }
}