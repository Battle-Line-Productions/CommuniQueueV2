using Microsoft.Extensions.Logging;

namespace CommuniQueueV2.EventProcessor.Middleware;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
{
    public MessageHandlerDelegate Wrap(MessageHandlerDelegate next)
    {
        return async (message, context) =>
        {
            try
            {
                // Execute the next middleware in the pipeline
                await next(message, context);
            }
            catch (Exception ex)
            {
                // Log exception details in JSON format similar to API logs
                logger.LogError(ex,
                    "SQS Processing Error: {MessageId}; ErrorType={ErrorType}; ErrorMessage={ErrorMessage}; StackTrace={StackTracePreview}",
                    message.MessageId,
                    ex.GetType().Name,
                    ex.Message,
                    GetStackTracePreview(ex)
                );

                throw; // Rethrow to be handled by the function
            }
        };
    }

    private static string GetStackTracePreview(Exception ex)
    {
        if (string.IsNullOrEmpty(ex.StackTrace))
            return string.Empty;

        const int maxLength = 500;

        return ex.StackTrace.Length <= maxLength
            ? ex.StackTrace
            : string.Concat(ex.StackTrace.AsSpan(0, maxLength), "... [truncated]");
    }
}
