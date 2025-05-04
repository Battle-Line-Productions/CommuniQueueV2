using System.Text.Json;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using CommuniQueueV2.EventProcessor.Interfaces;
using CommuniQueueV2.EventProcessor.Middleware;
using Microsoft.Extensions.Logging;

namespace CommuniQueueV2.EventProcessor.Services;

public class MessageProcessor(
    ILogger<MessageProcessor> logger,
    IMessageHandler messageHandler,
    LoggingMiddleware loggingMiddleware,
    ErrorHandlingMiddleware errorHandlingMiddleware)
    : IMessageProcessor
{
    public async Task ProcessAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        // Extract correlation ID from message attributes or create a new one
        var correlationId = ExtractCorrelationId(message);
        var traceId = ExtractTraceId(message);

        // Create a logging scope for this message that matches API style
        using (logger.BeginScope(new Dictionary<string, object>
        {
            ["CorrelationId"] = correlationId,
            ["TraceId"] = traceId,
            ["MessageId"] = message.MessageId,
            ["QueueArn"] = message.EventSourceArn,
            ["AwsRequestId"] = context.AwsRequestId
        }))
        {
            // Build the middleware pipeline
            // The pipeline flows: Logging -> Error Handling -> Message Handler

            // Start with the core handler
            MessageHandlerDelegate pipeline = async (msg, ctx) =>
            {
                await messageHandler.HandleMessageAsync(msg, ctx);
            };

            // Wrap with error handling middleware
            pipeline = errorHandlingMiddleware.Wrap(pipeline);

            // Wrap with logging middleware (outermost)
            pipeline = loggingMiddleware.Wrap(pipeline);

            // Execute the pipeline
            await pipeline(message, context);
        }
    }

    private static string ExtractCorrelationId(SQSEvent.SQSMessage message)
    {
        // Try to extract correlation ID from message attributes
        if (message.MessageAttributes != null &&
            message.MessageAttributes.TryGetValue("CorrelationId", out var attribute) &&
            !string.IsNullOrEmpty(attribute.StringValue))
        {
            return attribute.StringValue;
        }

        // Try to extract from message body if it's JSON with a correlationId field
        try
        {
            using var doc = JsonDocument.Parse(message.Body);
            if (doc.RootElement.TryGetProperty("correlationId", out var element) &&
                element.ValueKind == JsonValueKind.String)
            {
                return element.GetString() ?? Guid.NewGuid().ToString();
            }
        }
        catch
        {
            // Ignore parsing errors - not JSON or doesn't have the expected structure
        }

        // Fallback: Use message ID or generate a new GUID
        return message.MessageId ?? Guid.NewGuid().ToString();
    }

    private static string ExtractTraceId(SQSEvent.SQSMessage message)
    {
        // Try to extract trace ID from message attributes
        if (message.MessageAttributes != null &&
            message.MessageAttributes.TryGetValue("TraceId", out var attribute) &&
            !string.IsNullOrEmpty(attribute.StringValue))
        {
            return attribute.StringValue;
        }

        // Try to extract from message body if it's JSON with a traceId field
        try
        {
            using var doc = JsonDocument.Parse(message.Body);
            if (doc.RootElement.TryGetProperty("traceId", out var element) &&
                element.ValueKind == JsonValueKind.String)
            {
                return element.GetString() ?? Guid.NewGuid().ToString();
            }
        }
        catch
        {
            // Ignore parsing errors
        }

        // Fallback to new GUID
        return Guid.NewGuid().ToString();
    }
}
