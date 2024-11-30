namespace AspNetCore.ApiVersioningTest.Models
{
    /// <summary>
    /// Represents a weather forecast with temperature and summary details.
    /// </summary>
    /// <param name="Date">The date of the forecast.</param>
    /// <param name="TemperatureC">The temperature in Celsius.</param>
    /// <param name="Summary">A brief description of the weather.</param>
    public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
    {
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }
}
