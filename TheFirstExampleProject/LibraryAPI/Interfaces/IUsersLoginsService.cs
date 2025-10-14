using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Requests;

namespace LibraryAPI.Interfaces;

public interface IUsersLoginsService
{
    // User and Login
    Task<IActionResult> GetAllUsersAsync();
    Task<IActionResult> GetUserByIdAsync(int id);
    Task<IActionResult> CreateNewUserAndLoginAsync(UserQuery newUser);
    Task<IActionResult> EditUserAndLoginAsync(int id, UserQuery selectedUser);
    Task<IActionResult> DeleteUserAndLoginAsync(int id);
    
    // Book and Genre
    Task<IActionResult> GetAllBookAsync();
}