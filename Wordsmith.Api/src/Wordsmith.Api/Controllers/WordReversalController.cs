using Microsoft.AspNetCore.Mvc;
using Wordsmith.Api.Models;

namespace Wordsmith.Api.Controllers;

[ApiController]
[Route("word-reversal")]
public class WordReversalController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WordReversalController> _logger;

    public WordReversalController(ILogger<WordReversalController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return new List<WeatherForecast>();
    }

    [HttpPost]
    public Task<WordReversalResponse> Post([FromBody] WordReversalRequest request)
    {
        return Task.FromResult(new WordReversalResponse {
            Input = "Hej",
            Reversed = "jeH"

        });
    }
}
