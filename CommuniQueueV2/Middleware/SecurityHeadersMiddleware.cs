using Microsoft.AspNetCore.Http;

namespace CommuniQueueV2.Middleware;

public class SecurityHeadersMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        // Basic security headers
        context.Response.Headers["X-Frame-Options"] = "DENY";
        context.Response.Headers["X-Content-Type-Options"] = "nosniff";

        // Cross-site scripting protection (useful for older browsers)
        context.Response.Headers["X-XSS-Protection"] = "1; mode=block";

        // Strict Transport Security (HSTS)
        // Forces browsers to use HTTPS for a specified time (1 year = 31536000 seconds)
        context.Response.Headers["Strict-Transport-Security"] = "max-age=31536000; includeSubDomains; preload";

        // Referrer Policy
        // Controls how much referrer information is included with requests
        context.Response.Headers["Referrer-Policy"] = "strict-origin-when-cross-origin";

        // Permissions Policy (formerly Feature Policy)
        // Restricts which browser features can be used
        context.Response.Headers["Permissions-Policy"] =
            "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()";

        // Content Security Policy (CSP)
        // Controls which resources the browser is allowed to load
        context.Response.Headers["Content-Security-Policy"] =
            "default-src 'self'; " +
            "script-src 'self' https://trusted-cdn.com; " +
            "style-src 'self' https://trusted-cdn.com; " +
            "img-src 'self' data: https:; " +
            "font-src 'self'; " +
            "connect-src 'self'; " +
            "media-src 'self'; " +
            "object-src 'none'; " +
            "frame-src 'none'; " +
            "frame-ancestors 'none'; " +
            "base-uri 'self'; " +
            "form-action 'self'; " +
            "upgrade-insecure-requests; " +
            "block-all-mixed-content";

        // Cross-Origin Resource Sharing (CORS) headers
        // If not using ASP.NET Core's built-in CORS middleware
        // context.Response.Headers["Access-Control-Allow-Origin"] = "https://yourtrustedorigin.com";

        // Cross-Origin Opener Policy (COOP)
        // Controls how your page can be accessed by other pages
        context.Response.Headers["Cross-Origin-Opener-Policy"] = "same-origin";

        // Cross-Origin Embedder Policy (COEP)
        // Prevents loading resources that don't explicitly grant permission
        context.Response.Headers["Cross-Origin-Embedder-Policy"] = "require-corp";

        // Cross-Origin Resource Policy (CORP)
        // Prevents other origins from loading your resources
        context.Response.Headers["Cross-Origin-Resource-Policy"] = "same-origin";

        // Cache control
        // Prevents caching of sensitive information (consider if appropriate for your resources)
        // context.Response.Headers["Cache-Control"] = "no-store, max-age=0";

        // Clear Site Data
        // For logout pages to clear browser data (cookies, storage, cache)
        // Only set this on logout endpoints
        // if (context.Request.Path == "/logout") {
        //     context.Response.Headers["Clear-Site-Data"] = "\"cookies\", \"storage\"";
        // }

        await next(context);
    }
}

