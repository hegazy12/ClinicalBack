using DatabaseLayer;
using DatabaseLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicalBackend2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly classinter _context;
        public WeatherForecastController(classinter context)
        {
            _context = context;
        }

        private static readonly string[] Summaries =
        [
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        ];

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<List<Test>>> Get()
        {
            return Ok(await _context.GetAllTests());

        }
    }
}
