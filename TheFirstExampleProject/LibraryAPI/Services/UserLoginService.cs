using LibraryAPI.DatabaseContext;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryAPI.Interfaces;
using LibraryAPI.Requests;

namespace LibraryAPI.Services;

public class UserLoginService : IUsersLoginsService
{
    private readonly ContextDatabase _contextDatabase;

    public UserLoginService(ContextDatabase contextDatabase)
    {
        _contextDatabase = contextDatabase;
    }
    
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var users = _contextDatabase.Users.ToListAsync();

        return new OkObjectResult(new
        {
            data = new {users = users},
            status = true
        });
    }
    
    public async Task<IActionResult> CreateNewUserAndLoginAsync(UserPost newUser)
    {
        var login = new Login()
        {
            User = new User()
            {
                description = newUser.Description,
                name= newUser.Name,
            },
            password = newUser.Password,
            login = newUser.Login
        };

        await _contextDatabase.AddAsync(login);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true
        });
    }
}