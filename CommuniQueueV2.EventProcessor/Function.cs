using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using CommuniQueueV2.EventProcessor.Interfaces;
using Microsoft.Extensions.Logging;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace CommuniQueueV2.EventProcessor;

public class Function(ILogger<Function> logger, IMessageProcessor messageProcessor)
{
    [LambdaFunction]
    public async Task FunctionHandler(SQSEvent evnt, ILambdaContext context)
    {
        logger.LogInformation(
            "Lambda Invocation: {FunctionName} with {MessageCount} messages; AwsRequestId={AwsRequestId}",
            context.FunctionName,
            evnt.Records.Count,
            context.AwsRequestId
        );

        foreach (var message in evnt.Records)
        {
            try
            {
                await messageProcessor.ProcessAsync(message, context);
            }
            catch (Exception ex)
            {
                // Log at function level but don't rethrow - this allows processing to continue for other messages
                logger.LogError(ex,
                    "Unhandled Exception: {MessageId}; ErrorType={ErrorType}; ErrorMessage={ErrorMessage}",
                    message.MessageId,
                    ex.GetType().Name,
                    ex.Message
                );
            }
        }

        logger.LogInformation(
            "Lambda Completed: {FunctionName}; AwsRequestId={AwsRequestId}; RemainingTime={RemainingTime}ms",
            context.FunctionName,
            context.AwsRequestId,
            context.RemainingTime.TotalMilliseconds
        );
    }
}
