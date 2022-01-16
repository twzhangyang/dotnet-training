using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NLog;
using NLog.Web;
using WebApi.Error;
using WebApi.HealthCheck;
using WebApi.Repository;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

// NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

// Entity Framework Inmemory
    builder.Services.AddDbContext<MusicDbContext>(opt =>
        opt.UseInMemoryDatabase("music-db"));

// Health check
    builder.Services.AddHealthChecks()
        .AddCheck<SampleHealthCheck>("Sample")
        .AddCheck<StartupHealthCheck>(
            "Startup",
            tags: new[] { "ready" })
        .AddDbContextCheck<MusicDbContext>("Database", tags: new[] { "ready" });

    builder.Services.AddHostedService<StartupBackgroundService>();
    builder.Services.AddSingleton<StartupHealthCheck>();

// Add services to the container.
    builder.Services.AddControllers(options => { options.Filters.Add<HttpResponseExceptionFilter>(); });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

// Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

// Configure error handling
    app.ConfigureExceptionHandler(app.Environment);

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    app.MapHealthChecks("/healthz", new HealthCheckOptions
    {
        ResultStatusCodes =
        {
            [HealthStatus.Healthy] = StatusCodes.Status200OK,
            [HealthStatus.Degraded] = StatusCodes.Status200OK,
            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
        },
        Predicate = healthCheck => healthCheck.Name.Equals("Sample")
    });
    app.MapHealthChecks("/healthz/ready", new HealthCheckOptions
    {
        Predicate = healthCheck => healthCheck.Tags.Contains("ready")
    });

    app.MapHealthChecks("/healthz/live", new HealthCheckOptions
    {
        Predicate = _ => false
    });

    app.Run();
}
catch (Exception e)
{
    logger.Error(e, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}
