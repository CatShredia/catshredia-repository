using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Interfaces;
using LibraryAPI.Requests;

namespace LibraryAPI.Controllers;

public class LibraryController
{
    // User and Login
    private readonly ILibraryService _libraryService;

    public LibraryController(ILibraryService libraryService)
    {
        _libraryService = libraryService;
    }

    [HttpGet]
    [Route("getAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        return await _libraryService.GetAllUsersAsync();
    }
    
    [HttpGet("user/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return await _libraryService.GetUserByIdAsync(id);
    }
    
    [HttpPost]
    [Route("createNewUserAndLogin")]
    public async Task<IActionResult> CreateNewUserAndLogin(UserQuery newUser)
    {
        return await _libraryService.CreateNewUserAndLoginAsync(newUser);
    }
    
    [HttpPut]
    [Route("editUserAndLogin/{id}")]
    public async Task<IActionResult> EditUserAndLogin(int id, UserQuery selectedUser)
    {
        return await _libraryService.EditUserAndLoginAsync(id, selectedUser);
    }
    
    [HttpDelete]
    [Route("deleteUserAndLogin/{id}")]
    public async Task<IActionResult> DeleteUserAndLogin(int id)
    {
        return await _libraryService.DeleteUserAndLoginAsync(id);
    }

    
    // books and genre
    [HttpGet]
    [Route("getAllBooks")]
    public async Task<IActionResult> GetAllBooks()
    {
        return await _libraryService.GetAllBooksAsync();
    }
}