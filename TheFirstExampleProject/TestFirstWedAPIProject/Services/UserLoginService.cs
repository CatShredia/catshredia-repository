using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestFirstWedAPIProject.DatabaseContext;
using TestFirstWedAPIProject.Interfaces;

namespace TestFirstWedAPIProject.Services;

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
}