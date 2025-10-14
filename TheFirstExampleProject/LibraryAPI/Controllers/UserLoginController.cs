using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Interfaces;
using LibraryAPI.Requests;

namespace LibraryAPI.Controllers;

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
    public async Task<IActionResult> CreateNewUserAndLogin(UserQuery newUser)
    {
        return await _usersLoginsService.CreateNewUserAndLoginAsync(newUser);
    }
    
    [HttpPost]
    [Route("editUserAndLogin")]
    public async Task<IActionResult> EditUserAndLogin(SpecificUserQuery selectedUser)
    {
        return await _usersLoginsService.EditUserAndLoginAsync(selectedUser);
    }
}