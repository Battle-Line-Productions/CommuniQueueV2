using Amazon.Lambda.Annotations;
using Microsoft.Extensions.DependencyInjection;

namespace CommuniQueueV2.EventProcessor;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Register your services here
        //services.AddSingleton<IMyService, MyService>();
        // Add other services as needed
    }
}
