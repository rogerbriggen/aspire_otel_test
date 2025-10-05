using Microsoft.AspNetCore.Mvc;
using OtelLib;
using Serilog;

namespace aspire_otel_test.Controllers;


[ApiController]
[Route("[controller]")]
public class WeatherForecastSerilogController(ILogger<OtelTest> otelTestLogger) : ControllerBase
{
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];
    private readonly Serilog.ILogger logger = Log.Logger.ForContext<WeatherForecastSerilogController>();

    
    private readonly OtelTest otelTest = new(otelTestLogger);

    [HttpGet(Name = "GetWeatherForecastSerilog")]
    public IEnumerable<WeatherForecast> Get()
    {
        
        var returnValue = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
        otelTest.GenerateMetric(1, "weather_forecast_generated");
        logger.Information("Generating weather forecast {@WeatherForecast}", returnValue);
        return returnValue;
    }
}
