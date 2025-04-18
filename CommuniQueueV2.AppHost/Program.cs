var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.CommuniQueueV2_ApiService>("apiservice");

builder.AddProject<Projects.CommuniQueueV2_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

await builder.Build().RunAsync();
