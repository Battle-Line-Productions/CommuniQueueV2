using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace CommuniQueueV2.Middleware;

[ExcludeFromCodeCoverage]
public class CorrelationTokenMiddleware(
    RequestDelegate next,
    IOptions<CorrelationTokenMiddleware.CorrelationIdOptions> options)
{
    private readonly RequestDelegate _next = next ?? throw new ArgumentNullException(nameof(next));
    private readonly CorrelationIdOptions _options = options?.Value ?? throw new ArgumentNullException(nameof(options));

    public async Task InvokeAsync(HttpContext context)
    {
        // 1) Try to read an incoming correlation ID from the request header
        var incomingCorrelationId = GetCallerCorrelationIdFromRequest(context);

        // 2) If none exists, generate a new GUID
        context.TraceIdentifier = incomingCorrelationId ?? Guid.NewGuid().ToString();

        // 3) Optionally attach correlation ID to the response header
        if (_options.IncludeInResponse)
        {
            context.Response.OnStarting(() =>
            {
                context.Response.Headers[_options.Header] = context.TraceIdentifier;
                return Task.CompletedTask;
            });
        }

        // 4) Push correlation ID into Serilog's LogContext
        //    so all subsequent log entries have "CorrelationId" property
        using (LogContext.PushProperty("CorrelationId", context.TraceIdentifier))
        {
            await _next(context);
        }
    }

    private string? GetCallerCorrelationIdFromRequest(HttpContext context)
    {
        // If the request has the correlation header, return its value
        return context.Request.Headers.TryGetValue(_options.Header, out var correlationId)
            ? correlationId.ToString()
            : null;
    }

    public class CorrelationIdOptions
    {
        public string Header { get; set; } = "X-Correlation-Id";
        public bool IncludeInResponse { get; set; } = true;
    }
}
