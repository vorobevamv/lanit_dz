using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lanitlesson02.Controllers
{
    /* [ApiController]
     [Route("[controller]")]
     public class WeatherForecastController : ControllerBase
     {
         private static readonly string[] Summaries = new[]
         {
             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         };

         private readonly ILogger<WeatherForecastController> _logger;

         public WeatherForecastController(ILogger<WeatherForecastController> logger)
         {
             _logger = logger;
         }

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
         } //ТУТ БЕЗ ИЗМЕНЕНИЙ

         [HttpGet("aaa")]
         public string BlaBla()
         {
             return "blablabla";
         }
         [HttpPost("setset")]
         public string GetItem(string nnn, string value)
         {
             return value + "kkk";
         }
     }*/

    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpPost("tostu")]
        public string ToStu([FromBody] Student request)
        {
            if (request.Age > 15)
            {
                return "OK";
            }
            return "NO";
        }


    }
}