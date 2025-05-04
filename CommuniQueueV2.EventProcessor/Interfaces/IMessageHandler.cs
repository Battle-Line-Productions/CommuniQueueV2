using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

namespace CommuniQueueV2.EventProcessor.Interfaces;

public interface IMessageHandler
{
    Task HandleMessageAsync(SQSEvent.SQSMessage message, ILambdaContext context);
}
