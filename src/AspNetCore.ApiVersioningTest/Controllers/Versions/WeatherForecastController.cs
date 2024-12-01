using Asp.Versioning;
using AspNetCore.ApiVersioningTest.Constants;
using AspNetCore.ApiVersioningTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore.ApiVersioningTest.Controllers.Versions
{
    /// <summary>
    /// Controller for managing weather forecasts.
    /// </summary>
    [ApiVersion(ApiVersions.MINOR_VERSION_NUMBER)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class WeatherForecastController : ControllerBase
    {

        /// <summary>
        /// Retrieves a list of weather forecasts.
        /// </summary>
        /// <returns>A collection of weather forecast data.</returns>
        /// <response code="200">WeatherForecast retrieved</response>
        [HttpGet("weather-forecast")]
        [ProducesResponseType(200)]
        public IActionResult GetWeatherForecast(CancellationToken cancellationToken)
        {
            var summaries = new[]
                            {
                                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
                            };

            var forecast = Enumerable.Range(1, 5).Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        )).ToArray();

            return Ok(forecast);
        }

        /// <summary>
        /// Retrieves the API version information.
        /// </summary>
        /// <returns>The current API version.</returns>
        /// <response code="200">version retrieved</response>
        [HttpGet("version")] // Explicit HTTP method attribute
        [ProducesResponseType(200)]
        public IActionResult GetVersion(CancellationToken cancellationToken)
        {
            return Ok($"This the version number {ApiVersions.MINOR_VERSION_NUMBER}");
        }
    }

}
