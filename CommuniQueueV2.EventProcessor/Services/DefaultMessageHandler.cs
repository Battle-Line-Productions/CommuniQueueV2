using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;
using CommuniQueueV2.EventProcessor.Interfaces;
using Microsoft.Extensions.Logging;

namespace CommuniQueueV2.EventProcessor.Services;

public class DefaultMessageHandler(ILogger<DefaultMessageHandler> logger) : IMessageHandler
{
    public async Task HandleMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context)
    {
        logger.LogInformation("Processing message body: {MessageBody}", message.Body);

        // TODO: Implement your business logic here

        await Task.CompletedTask;
    }
}
