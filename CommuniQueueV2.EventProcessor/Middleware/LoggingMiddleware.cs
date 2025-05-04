using Amazon.Lambda.SQSEvents;
using System.Diagnostics;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace CommuniQueueV2.EventProcessor.Middleware;

public class LoggingMiddleware(ILogger<LoggingMiddleware> logger)
{
    public MessageHandlerDelegate Wrap(MessageHandlerDelegate next)
    {
        return async (message, context) =>
        {
            // Skip logging for certain message types if needed
            if (ShouldSkipLogging(message))
            {
                await next(message, context);
                return;
            }

            // Start timing
            var stopwatch = Stopwatch.StartNew();

            // Log the incoming message (similar to request logging)
            LogIncomingMessage(message);

            try
            {
                // Execute the next middleware in the pipeline
                await next(message, context);

                // Log the processing result (similar to response logging)
                stopwatch.Stop();
                LogProcessingResult(message, stopwatch.Elapsed, success: true);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                LogProcessingResult(message, stopwatch.Elapsed, success: false, exception: ex);
                throw; // Rethrow to be handled by error middleware
            }
        };
    }

    private void LogIncomingMessage(SQSEvent.SQSMessage message)
    {
        var messageAttributes = GetFilteredMessageAttributes(message);
        var messageSize = message.Body?.Length ?? 0;

        logger.LogInformation(
            "SQS Message Received: {MessageId} from {QueueArn}; Size={Size}; Attributes={Attributes}; Body={MessageBodyPreview}",
            message.MessageId,
            message.EventSourceArn,
            messageSize,
            JsonSerializer.Serialize(messageAttributes),
            GetMessageBodyPreview(message.Body)
        );
    }

    private void LogProcessingResult(SQSEvent.SQSMessage message, TimeSpan duration, bool success, Exception? exception = null)
    {
        if (success)
        {
            logger.LogInformation(
                "SQS Message Processed: {MessageId} in {Duration} ms; Status=Success",
                message.MessageId,
                duration.TotalMilliseconds.ToString("F2")
            );
        }
        else
        {
            logger.LogWarning(
                "SQS Message Failed: {MessageId} after {Duration} ms; Status=Failed; Error={ErrorMessage}",
                message.MessageId,
                duration.TotalMilliseconds.ToString("F2"),
                exception?.Message
            );
        }
    }

    // Skip logging for certain message types if needed (similar to health checks in API)
    private static bool ShouldSkipLogging(SQSEvent.SQSMessage message)
    {
        // Example: Skip logging for health check messages
        // In real implementation, define your own criteria
        return message.Body?.Contains("health-check", StringComparison.OrdinalIgnoreCase) == true;
    }

    // Filter out sensitive attributes (similar to header filtering in API)
    private static Dictionary<string, string> GetFilteredMessageAttributes(SQSEvent.SQSMessage message)
    {
        var result = new Dictionary<string, string>();

        if (message.MessageAttributes == null)
            return result;

        foreach (var attr in message.MessageAttributes)
        {
            // Skip sensitive attributes
            if (attr.Key.Contains("Password", StringComparison.OrdinalIgnoreCase) ||
                attr.Key.Contains("Secret", StringComparison.OrdinalIgnoreCase) ||
                attr.Key.Contains("Key", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            result[attr.Key] = attr.Value.StringValue ?? string.Empty;
        }

        return result;
    }

    // Only show a preview of the message body to avoid logging large messages
    private static string GetMessageBodyPreview(string body)
    {
        if (string.IsNullOrEmpty(body))
            return string.Empty;

        const int maxLength = 500;

        if (body.Length <= maxLength)
            return body;

        return body[..maxLength] + "... [truncated]";
    }
}
