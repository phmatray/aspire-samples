namespace BlueModule.Domain;

/// <summary>
/// Represents a weather forecast.
/// </summary>
/// <param name="Date">The date of the forecast.</param>
/// <param name="TemperatureC">The temperature in Celsius.</param>
/// <param name="Summary">The summary of the forecast.</param>
public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    /// <summary>
    /// Gets the temperature in Fahrenheit.
    /// </summary>
    /// <returns>The temperature in Fahrenheit.</returns>
    public int TemperatureF
        => 32 + (int)(TemperatureC / 0.5556);
}