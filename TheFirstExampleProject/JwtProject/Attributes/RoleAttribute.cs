using JwtProject.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace JwtProject.Security.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RoleAttribute : Attribute, IAsyncActionFilter
{

    private int[] ids_role;

    public RoleAttribute(int[] _ids_role)
    {
        ids_role = _ids_role;
    }
    
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var dbContext = context.HttpContext.RequestServices.GetRequiredService<ContextDatabase>();
        string? token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
        
        if (string.IsNullOrEmpty(token))
        {
            context.Result = new JsonResult(new { error = "Session don't transfer" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            return;
        }

        var session = await dbContext.Sessions.Include(x => x.User)
            .FirstOrDefaultAsync(session => session.name == token);

        if (session == null)
        {
            context.Result = new JsonResult(new { error = "Session not found" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            
            return;
        }

        if (!ids_role.Contains(session.User.id_role))
        {
            context.Result = new JsonResult(new { error = "Haven't permissions" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            
            return;
        }

        await next();
    }
}