using Amazon.Lambda.Core;
using Amazon.Lambda.SQSEvents;

namespace CommuniQueueV2.EventProcessor.Middleware;

public delegate Task MessageHandlerDelegate(SQSEvent.SQSMessage message, ILambdaContext context);

