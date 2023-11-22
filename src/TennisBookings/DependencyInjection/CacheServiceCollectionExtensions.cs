using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection
{
	public static class CacheServiceCollectionExtensions
	{
		public static IServiceCollection CacheServices(this IServiceCollection services)
		{
			//services.TryAddSingleton<IDistributedCache<UserGreeting>, DistributedCache<UserGreeting>>();
			services.TryAddSingleton(typeof(IDistributedCache<>), typeof(DistributedCache<>));

			return services;
		}
	}
}
