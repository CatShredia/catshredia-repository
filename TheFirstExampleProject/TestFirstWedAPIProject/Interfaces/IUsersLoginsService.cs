using Microsoft.AspNetCore.Mvc;
using TestWebApi321.Requests;

namespace TestFirstWedAPIProject.Interfaces;

public interface IUsersLoginsService
{
    Task<IActionResult> GetAllUsersAsync();
    
    Task<IActionResult> CreateNewUserAndLoginAsync(UserPost newUser);
}