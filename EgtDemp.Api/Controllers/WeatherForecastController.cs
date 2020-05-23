using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgtDemp.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EgtDemp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDemoRepo _demoRepo;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IDemoRepo demoRepo)
        {
            _logger = logger;
            _demoRepo = demoRepo;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var demos = _demoRepo.GetDemos();

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
