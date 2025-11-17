using JwtProject.Database;
using JwtProject.Interfaces;
using JwtProject.Models;
using JwtProject.Queries;
using JwtProject.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AuthService : IAuthService
{
    private readonly ContextDatabase _context;
    private readonly JwtTokensGenerator _jwtGenerator;

    public AuthService(ContextDatabase context, JwtTokensGenerator jwtGenerator)
    {
        _context = context;
        _jwtGenerator = jwtGenerator;
    }

    public async Task<IActionResult> AuthorizationUserAsync(LoginQuery query)
    {
        var login = await _context.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.login == query.name && l.password == query.password);

        if (login == null)
            return new NotFoundObjectResult(new { status = false, message = "Invalid credentials." });

        string token = _jwtGenerator.GenerateJwtToken(login.id_user, login.User.id_role);

        _context.Sessions.Add(new Session { name = token, id_user = login.id_user });
        await _context.SaveChangesAsync();

        return new OkObjectResult(new { status = true, data = token });
    }

    public async Task<IActionResult> GetProfileAsync(string authorization)
    {
        var session = await _context.Sessions
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.name == authorization);

        return session == null
            ? new NotFoundObjectResult(new { status = false, message = "Session not found." })
            : new OkObjectResult(new { status = true, selectedUser = session });
    }

    public async Task<IActionResult> UpdateProfileAsync(string authorization, UserLoginQuery query)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(s => s.name == authorization);
        if (session == null)
            return new NotFoundObjectResult(new { status = false, message = "Session not found." });

        var login = await _context.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.id_user == session.id_user);

        if (login == null)
            return new NotFoundObjectResult(new { status = false, message = "User not found." });

        login.login = query.login;
        login.password = query.password;
        login.User.name = query.nameUser;
        login.User.description = query.description;

        await _context.SaveChangesAsync();
        return new OkObjectResult(new { status = true, message = "Profile updated successfully." });
    }
}