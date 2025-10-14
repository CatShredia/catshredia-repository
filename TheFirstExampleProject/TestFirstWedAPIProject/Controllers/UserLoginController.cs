using Microsoft.AspNetCore.Mvc;
using TestFirstWedAPIProject.Interfaces;
using TestWebApi321.Requests;

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
    
    [HttpPost]
    [Route("createNewUserAndLogin")]
    public async Task<IActionResult> CreateNewUserAndLogin(UserPost newUser)
    {
        return await _usersLoginsService.CreateNewUserAndLoginAsync(newUser);
    }
}