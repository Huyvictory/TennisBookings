
namespace TennisBookings.Caching
{
	public class CachedWeatherForecaster : IRandomWeatherForecaster
	{
		private readonly IRandomWeatherForecaster _forecaster;
		private readonly IUtcTimeService _utcTimeService;
		private readonly IDistributedCache<WeatherResult> _cache;

		public CachedWeatherForecaster(
			IRandomWeatherForecaster forecaster,
			IUtcTimeService utcTimeService,
			IDistributedCache<WeatherResult> cache)
		{
			_forecaster = forecaster;
			_utcTimeService = utcTimeService;
			_cache = cache;
		}

		public async Task<WeatherResult> GetCurrentWeatherAsync(string city)
		{
			var cacheKey = $"weather_{city}_{_utcTimeService.CurrentUtcDateTime:yyyy_mm-dd}";

			var (isCached, forecast) = await _cache.TryGetValueAsync(cacheKey);

			if (isCached)
			{
				return forecast!;
			}

			var result = await _forecaster.GetCurrentWeatherAsync(city);

			await _cache.SetAsync(cacheKey, result, 60);

			return result;
		}
	}
}
