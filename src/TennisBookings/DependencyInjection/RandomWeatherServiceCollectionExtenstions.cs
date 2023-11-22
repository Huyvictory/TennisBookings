using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection
{
	public static class RandomWeatherServiceCollectionExtenstions
	{
		public static IServiceCollection WeatherForcastingServices(this IServiceCollection services)
		{
			services.TryAddSingleton<IRandomWeatherForecaster, AmazingWeatherForeCaster>();
			services.TryAddSingleton<IRandomWeatherForecaster, RandomWeatherForecaster>();
			//services.Replace(ServiceDescriptor.Singleton<IRandomWeatherForecaster, RandomWeatherForecaster>());
			//services.RemoveAll<IRandomWeatherForecaster>();

			return services;
		}
	}
}
