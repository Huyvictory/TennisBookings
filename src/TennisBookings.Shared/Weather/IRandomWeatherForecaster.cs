namespace TennisBookings.Shared.Weather
{
	public interface IRandomWeatherForecaster
	{
		Task<WeatherResult> GetCurrentWeatherAsync(string city);
	}
}
