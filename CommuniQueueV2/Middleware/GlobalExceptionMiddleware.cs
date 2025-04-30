using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace CommuniQueueV2.Middleware;

public class GlobalExceptionMiddleware(
    RequestDelegate next,
    ILogger<GlobalExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Pass request further down the pipeline
            await next(context);
        }
        catch (Exception ex)
        {
            // Catch any unhandled exceptions from the pipeline
            logger.LogError(ex, "Unhandled exception caught by global middleware.");

            // Return a well-formatted problem response
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json+problem";

        var correlationId = context.TraceIdentifier;

        var problem = new ProblemDetails
        {
            Title = "An unexpected error occurred.",
            Detail = exception.Message,
            Status = context.Response.StatusCode,
            Instance = context.Request.Path,
            Extensions = { ["CorrelationId"] = correlationId }
        };

        return context.Response.WriteAsJsonAsync(problem);
    }
}
