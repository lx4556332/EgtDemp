using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EgtDemp.IRepo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        private IConfiguration _configuration { get; set; }

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IDemoRepo demoRepo, IConfiguration configuration)
        {
            _logger = logger;
            _demoRepo = demoRepo;
            this._configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            var demos = _demoRepo.GetDemos();
            Console.WriteLine(JsonConvert.SerializeObject(demos));
            Console.WriteLine($"config:{_configuration["consul_config"]}");
            //var aa= _configuration.GetValue<string>("MySettings:ApplicationName");
            //.GetSection("Data").GetSection("ConnectionString").Value;
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
