using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiDemoApp.Controllers;

[ApiController]
[Route("[controller]")]
//[Authorize] :  Default Authorization is happaning 
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IDateTime _dateTime;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IDateTime dateTime)
    {
        _logger = logger;
        _dateTime = dateTime;

    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("/DateTime")]
    public DateTime GetDateTime()
    {
        return _dateTime.Now;
    }
}
