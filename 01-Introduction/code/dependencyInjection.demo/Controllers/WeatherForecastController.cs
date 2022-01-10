using dependencyInjection.demo.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dependencyInjection.demo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IOperationTransient _transient;
    private readonly IOperationScoped _scoped;
    private readonly IOperationSingleton _singleton;

    public WeatherForecastController(IOperationTransient transient, IOperationScoped scoped, IOperationSingleton singleton, ILogger<WeatherForecastController> logger)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
        _logger = logger;
    }

    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;


    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogError("Transient: " + _transient.OperationId);
        _logger.LogError("Scoped: "    + _scoped.OperationId);
        _logger.LogError("Singleton: " + _singleton.OperationId);

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
