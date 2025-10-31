using JwtProject.Database;
using JwtProject.Model;

public class LoggingMiddleware
{
    // функция, запускаемая при любом HTTP запросе
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, ContextDatabase dbContext)
    {
        var request = context.Request;
        var originalBodyStream = request.Body;

        var method = request.Method;
        var url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
        var userAgent = request.Headers["User-Agent"].ToString();

        await _next(context);

        dbContext.Logs.Add(new Logs()
        {
            Method = method,
            Url = url,
            UserAgent = userAgent,
            CreatedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync();
    }
}