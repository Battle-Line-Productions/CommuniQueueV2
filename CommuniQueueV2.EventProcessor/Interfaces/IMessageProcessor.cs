using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

namespace CommuniQueueV2.EventProcessor.Interfaces;

public interface IMessageProcessor
{
    Task ProcessAsync(SQSEvent.SQSMessage message, ILambdaContext context);
}
