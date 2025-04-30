using System.Text.Json.Serialization;
using Asp.Versioning;
using CommuniQueueV2.Middleware;
using CommuniQueueV2.ServiceDefaults;
using Microsoft.AspNetCore.RateLimiting;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, loggerConfig) =>
{
    loggerConfig
        .ReadFrom.Configuration(ctx.Configuration)
        .Enrich.FromLogContext()
        .WriteTo.Console();
});

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Fixed", limiterOptions =>
    {
        limiterOptions.PermitLimit = 100;
        limiterOptions.Window = TimeSpan.FromMinutes(1);
        limiterOptions.QueueLimit = 2;
    });
});

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddResponseCompression();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, _) =>
    {
        document.Info = new()
        {
            Title = "CommuniQueue API",
            Version = "v1",
            Description = """
                          Modern API for managing messaging templates.
                          Supports JSON responses.
                          """,
            Contact = new()
            {
                Name = "Battleline Customer Service",
                Email = "customerservice@battleline.com",
                Url = new Uri("https://battlelineproductions.com")
            }
        };
        return Task.CompletedTask;
    });
});

var app = builder.Build();

app.UseMiddleware<SecurityHeadersMiddleware>();
app.UseMiddleware<CorrelationTokenMiddleware>();
app.UseMiddleware<RequestResponseLoggingMiddleware>();
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.UseRateLimiter();

app.UseResponseCompression();

if (app.Environment.IsDevelopment())
{
    // https://blog.antosubash.com/posts/dotnet-openapi-with-scalar
    app.MapOpenApi().CacheOutput();
    app.MapScalarApiReference();

    app.MapGet("/", () => Results.Redirect("/scalar/v1"))
        .ExcludeFromDescription();
}

app.MapDefaultEndpoints();

await app.RunAsync();
