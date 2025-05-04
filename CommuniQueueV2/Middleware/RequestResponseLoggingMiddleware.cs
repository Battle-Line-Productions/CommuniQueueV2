using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CommuniQueueV2.Middleware;

[ExcludeFromCodeCoverage]
public class RequestResponseLoggingMiddleware(
    RequestDelegate next,
    ILogger<RequestResponseLoggingMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        // Start timing
        var stopwatch = Stopwatch.StartNew();

        // First log the incoming request
        LogRequest(context);

        // Let the pipeline continue
        await next(context);

        // Now log the response info
        stopwatch.Stop();
        LogResponse(context, stopwatch.Elapsed);
    }

    private void LogRequest(HttpContext context)
    {
        // Don’t log health-check requests (or any path you want to exclude)
        if (ShouldSkipLogging(context))
            return;

        logger.LogInformation(
            "HTTP Request: {Method} {Path} from {ClientIp}; QueryString={QueryString}; Headers={Headers}",
            context.Request.Method,
            context.Request.Path,
            context.Connection.RemoteIpAddress?.ToString(),
            context.Request.QueryString.ToString(),
            GetFilteredHeaders(context.Request.Headers, "Authorization", "X-Api-Key")
        );
    }

    private void LogResponse(HttpContext context, TimeSpan duration)
    {
        if (ShouldSkipLogging(context))
            return;

        logger.LogInformation(
            "HTTP Response: {StatusCode} for {Method} {Path} in {Duration} ms; Headers={Headers}",
            context.Response.StatusCode,
            context.Request.Method,
            context.Request.Path,
            duration.TotalMilliseconds.ToString("F2"),
            GetFilteredHeaders(context.Response.Headers, "Authorization", "X-Api-Key")
        );
    }

    // Utility to skip logging if path contains "health" or any other check
    private static bool ShouldSkipLogging(HttpContext context)
    {
        var path = context.Request.Path.Value ?? "";
        return path.Contains("health", StringComparison.OrdinalIgnoreCase);
    }

    // Filters out sensitive headers (Authorization, X-Api-Key, etc.)
    private static string GetFilteredHeaders(IHeaderDictionary headers, params string[] excludedHeaders)
    {
        var filteredHeaders = headers
            .Where(h => !excludedHeaders.Contains(h.Key, StringComparer.OrdinalIgnoreCase))
            .ToDictionary(h => h.Key, h => h.Value.ToString());

        return JsonSerializer.Serialize(filteredHeaders);
    }
}
