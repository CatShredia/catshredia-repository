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
            data = new { users = users },
            status = true
        });
    }

    public async Task<IActionResult> CreateNewUserAndLoginAsync(UserQuery newUser)
    {
        var login = new Login()
        {
            User = new User()
            {
                description = newUser.Description,
                name = newUser.Name,
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

    public async Task<IActionResult> EditUserAndLoginAsync(SpecificUserQuery selectedUser)
    {
        if (selectedUser.Id_User == null)
            return new BadRequestObjectResult(new { status = false, message = "User ID is required." });

        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == int.Parse(selectedUser.Id_User));

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        // Update Login properties
        existingLogin.login = selectedUser.Login;
        existingLogin.password = selectedUser.Password;

        // Update related User properties
        existingLogin.User.name = selectedUser.Name;
        existingLogin.User.description = selectedUser.Description;

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true
        });
    }
}