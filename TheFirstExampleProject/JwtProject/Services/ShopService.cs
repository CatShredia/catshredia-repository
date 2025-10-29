using JwtProject.Database;
using JwtProject.Interfaces;
using JwtProject.Model;
using JwtProject.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JwtProject.Services;

public class ShopService : IShopService
{
    private readonly ContextDatabase _contextDatabase;

    public ShopService(ContextDatabase contextDatabase)
    {
        _contextDatabase = contextDatabase;
    }
    
    public async Task<IActionResult> GetAllEmployeesAsync()
    {
        var employeesList = _contextDatabase.Users
            .Include(user => user.Role)
            .Where(user => user.Role.name == "employee");
        
        if (employeesList == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Employees not found." });
        } 

        return new OkObjectResult(new
        {
            status = true,
            data = employeesList
        });
    }

    public async Task<IActionResult> CreateEmployeeAsync(UserLoginQuery query)
    {
        var newLogin = new Login()
        {
            User = new User()
            {
                name = query.nameUser,
                description = query.description,
                id_role = 2
            },
            password = query.password,
            login = query.login,
        };
        
        await _contextDatabase.AddAsync(newLogin);
        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login created successfully."
        });
    }

    public async Task<IActionResult> UpdateEmployeeAsync(UserLoginQuery query, int id)
    {
        var existingLogin = await _contextDatabase.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == id);

        if (existingLogin == null)
        {
            return new NotFoundObjectResult(new { status = false, message = "Login not found." });
        }

        existingLogin.login = query.login;
        existingLogin.password = query.password;

        existingLogin.User.name = query.nameUser;
        existingLogin.User.description = query.description;

        await _contextDatabase.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "User and login edited successfully."
        });
    }

    public async Task<IActionResult> DeleteEmployeeAsync(int id)
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
}