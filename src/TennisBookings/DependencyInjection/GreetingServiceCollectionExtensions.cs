using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection
{
	public static class GreetingServiceCollectionExtensions
	{
		public static IServiceCollection GreetingServices(this IServiceCollection services)
		{
			services.TryAddSingleton<GreetingService>();
			services.TryAddSingleton<IHomePageGreetingService>(sp => sp.GetRequiredService<GreetingService>());
			services.TryAddSingleton<ILoggedInUserGreetingService>(sp => sp.GetRequiredService<GreetingService>());

			return services;
		}
	}
}
