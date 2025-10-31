using JwtProject.Database;
using JwtProject.Model;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context, ContextDatabase dbContext)
    {
        var request = context.Request;
        var originalBodyStream = request.Body;

        // Read request body (if needed)
        string? payload = null;
        if (request.ContentLength > 0 && request.ContentType?.Contains("application/json") == true)
        {
            using var reader = new StreamReader(request.Body);
            payload = await reader.ReadToEndAsync();
            request.Body = originalBodyStream; // Reset stream for controller
            request.Body.Position = 0;
        }

        // Capture data before response
        var method = request.Method;
        var url = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString}";
        var userId = context.User.FindFirst("sub")?.Value; // or use your claim
        var ip = context.Connection.RemoteIpAddress?.ToString();
        var userAgent = request.Headers["User-Agent"].ToString();

        await _next(context); // Process request

        // Log after response (you can also log before if preferred)
        dbContext.Logs.Add(new Logs()
        {
            Method = method,
            Url = url,
            UserId = userId,
            IpAddress = ip,
            Payload = payload,
            UserAgent = userAgent,
            CreatedAt = DateTime.UtcNow
        });

        await dbContext.SaveChangesAsync();
    }
}