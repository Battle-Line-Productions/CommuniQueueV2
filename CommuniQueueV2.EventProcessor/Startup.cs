using Amazon.Lambda.Annotations;
using CommuniQueueV2.EventProcessor.Interfaces;
using CommuniQueueV2.EventProcessor.Middleware;
using CommuniQueueV2.EventProcessor.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CommuniQueueV2.EventProcessor;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // Load configuration from appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Configure Serilog from settings
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Enrich.WithProperty("Service", "CommuniQueueV2.EventProcessor")
            .CreateLogger();

        // Register configuration
        services.AddSingleton<IConfiguration>(configuration);

        // Register Serilog to the .NET ILogger infrastructure
        services.AddLogging(builder =>
        {
            builder.ClearProviders();
            builder.AddSerilog(dispose: true);
        });

        services.AddDbContextPool<CommuniQueueDbContext>(opt =>
        {
            var conn = configuration.GetConnectionString("communiqueuedb");
            opt.UseSnakeCaseNamingConvention();
            opt.EnableDetailedErrors();
            opt.EnableSensitiveDataLogging();
            opt.UseNpgsql(conn, npgsql =>
            {
                npgsql.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorCodesToAdd: null
                );
            });
        }, poolSize: 128);

        // Register message processor
        services.AddSingleton<IMessageProcessor, MessageProcessor>();

        // Register middleware components
        services.AddSingleton<LoggingMiddleware>();
        services.AddSingleton<ErrorHandlingMiddleware>();

        // Register your actual message handler
        services.AddSingleton<IMessageHandler, DefaultMessageHandler>();
    }
}
