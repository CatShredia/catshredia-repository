using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Interfaces;
using LibraryAPI.Requests;

namespace LibraryAPI.Controllers;

public class UserLoginController
{
    // User and Login
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
    
    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return await _usersLoginsService.GetUserByIdAsync(id);
    }
    
    [HttpPost]
    [Route("createNewUserAndLogin")]
    public async Task<IActionResult> CreateNewUserAndLogin(UserQuery newUser)
    {
        return await _usersLoginsService.CreateNewUserAndLoginAsync(newUser);
    }
    
    [HttpPut]
    [Route("editUserAndLogin/{id}")]
    public async Task<IActionResult> EditUserAndLogin(int id, UserQuery selectedUser)
    {
        return await _usersLoginsService.EditUserAndLoginAsync(id, selectedUser);
    }
    
    [HttpDelete]
    [Route("deleteUserAndLogin/{id}")]
    public async Task<IActionResult> DeleteUserAndLogin(int id)
    {
        return await _usersLoginsService.DeleteUserAndLoginAsync(id);
    }

    
    // books and genre
    [HttpGet]
    [Route("getAllBooks")]
    public async Task<IActionResult> GetAllBooks()
    {
        return await _usersLoginsService.GetAllBookAsync();
    }
}