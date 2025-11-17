using JwtProject.Database;
using JwtProject.Interfaces;
using JwtProject.Model;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UserService : IUserService
{
    private readonly ContextDatabase _context;
    public UserService(ContextDatabase context) => _context = context;

    public async Task<IActionResult> GetAllUsersAsync(int id_role)
    {
        var users = await _context.Users
            .Where(u => u.id_role == id_role)
            .ToListAsync();

        return !users.Any()
            ? new NotFoundObjectResult(new { status = false, message = "Users not found." })
            : new OkObjectResult(new { status = true, data = users });
    }

    public async Task<IActionResult> CreateUserAsync(int id_role, UserLoginQuery query)
    {
        var newLogin = new Login
        {
            User = new User
            {
                name = query.nameUser,
                description = query.description,
                id_role = id_role
            },
            login = query.login,
            password = query.password
        };

        await _context.AddAsync(newLogin);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new { status = true, message = "User and login created successfully." });
    }

    public async Task<IActionResult> UpdateUserAsync(UserLoginQuery query, int id)
    {
        var login = await _context.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (login == null)
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });

        login.login = query.login;
        login.password = query.password;
        login.User.name = query.nameUser;
        login.User.description = query.description;

        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "User updated successfully." });
    }

    public async Task<IActionResult> DeleteUserAsync(int id)
    {
        var login = await _context.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (login == null)
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });

        _context.Logins.Remove(login);
        if (login.User != null) _context.Users.Remove(login.User);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new { status = true, message = "User deleted successfully." });
    }
}