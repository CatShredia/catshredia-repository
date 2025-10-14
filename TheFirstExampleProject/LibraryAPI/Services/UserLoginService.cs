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
    
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var user = await _contextDatabase.Users
            .FirstOrDefaultAsync(u => u.id_user == id); // assuming your User has Id

        if (user == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "User not found." });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = user
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
            status = true,
            message = "User and login created successfully."
        });
    }

    public async Task<IActionResult> EditUserAndLoginAsync(int id, UserQuery selectedUser)
    {
        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        existingLogin.login = selectedUser.Login;
        existingLogin.password = selectedUser.Password;

        existingLogin.User.name = selectedUser.Name;
        existingLogin.User.description = selectedUser.Description;

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login edited successfully."
        });
    }
    public async Task<IActionResult> DeleteUserAndLoginAsync(int id)
    {
        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User) 
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        _contextDatabase.Logins.Remove(existingLogin);
    
        if (existingLogin.User != null)
        {
            _contextDatabase.Users.Remove(existingLogin.User);
        }

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login deleted successfully."
        });
    }

    public async Task<IActionResult> GetAllBookAsync()
    {
        var books = _contextDatabase.Books.ToListAsync();

        return new OkObjectResult(new
        {
            data = new { books = books },
            status = true
        });
    }
}