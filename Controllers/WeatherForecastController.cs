using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApplication1.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing1", "Bracing1", "Chilly1", "Cool1", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// kjlfsldfkj lkdfgj
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [SwaggerOperation(
             Summary = " Создает новый продукт ",
             Description = " Требуются права администратора ",
             OperationId = " CreateProduct ",
             Tags = new[] { " Закупка ", " Продукты " }
        )]
        [HttpGet("weatherforecastID/{id}")]
        public IEnumerable<WeatherForecast> GetById(int id)
        {
            var rng = new Random();
            return Enumerable.Range(id, id).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
