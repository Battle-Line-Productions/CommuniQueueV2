using Microsoft.AspNetCore.Http;

namespace CommuniQueueV2.Middleware;

public class SecurityHeadersMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.Headers["X-Frame-Options"] = "DENY";
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";
        // add more as needed...
        await next(context);
    }
}
