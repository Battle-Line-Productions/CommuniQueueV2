var builder = DistributedApplication.CreateBuilder(args);

// Add API service
var apiService = builder.AddProject<Projects.CommuniQueueV2_ApiService>("apiservice");

// Add Lambda processor as a container
//var lambdaProcessor = builder.AddContainer("eventprocessor", "communiquev2-processor")
//    .WithEnvironment("AWS_LAMBDA_FUNCTION_TIMEOUT", "900") // 15 minutes
//    .WithEnvironment("SQS_QUEUE_URL", "https://sqs.us-east-1.amazonaws.com/your-account-id/your-queue-name")
//    .WithEnvironment("AWS_REGION", "us-east-1");
// Add other environment variables as needed

// Add web frontend
builder.AddProject<Projects.CommuniQueueV2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);
    //.WaitFor(lambdaProcessor);

await builder.Build().RunAsync();
