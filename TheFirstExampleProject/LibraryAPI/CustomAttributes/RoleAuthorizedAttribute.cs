using LibraryAPI.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.CustomAttributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class RoleAuthorizedAttribute : Attribute , IAsyncActionFilter
{
    private readonly int _roleId;
    public RoleAuthorizedAttribute(int roleId)
    {
        _roleId = roleId;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var dbContext = context.HttpContext.RequestServices.GetRequiredService<ContextDatabase>();
        string? token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
    
        if (string.IsNullOrEmpty(token))
        {
            context.Result = new JsonResult(new {error = "Session don't transfer"}) {StatusCode = StatusCodes.Status401Unauthorized};
            return;
        }
    
        var session = await dbContext.Sessions.Include(x => x.User).FirstOrDefaultAsync(session => session.name == token);
    
        if (session == null)
        {
            context.Result = new JsonResult(new {error = "Session not found"}) {StatusCode = StatusCodes.Status401Unauthorized};
        }
        
        if (session.User.id_role != _roleId)
        {
            context.Result = new JsonResult(new {error = "Haven't permissions"}) {StatusCode = StatusCodes.Status401Unauthorized};
        }

        await next();
    }
}