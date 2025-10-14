using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Requests;

namespace LibraryAPI.Interfaces;

public interface IUsersLoginsService
{
    Task<IActionResult> GetAllUsersAsync();
    
    Task<IActionResult> CreateNewUserAndLoginAsync(UserPost newUser);
}