using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection
{
	public static class UnavailabilityServiceCollectionExtenstions
	{
		public static IServiceCollection UnavailabilityServices(this IServiceCollection services)
		{
			//services.TryAddEnumerable(ServiceDescriptor.Scoped<IUnavailabilityProvider, ClubClosedUnavailabilityProvider>());
			services.TryAddEnumerable(new ServiceDescriptor[]
			{
				ServiceDescriptor.Scoped<IUnavailabilityProvider, ClubClosedUnavailabilityProvider>(),
				ServiceDescriptor.Scoped<IUnavailabilityProvider, ClubClosedUnavailabilityProvider>(),
				ServiceDescriptor.Scoped<IUnavailabilityProvider, UpcomingHoursUnavailabilityProvider>(),
				ServiceDescriptor.Scoped<IUnavailabilityProvider, OutsideCourtUnavailabilityProvider>(),
				ServiceDescriptor.Scoped<IUnavailabilityProvider, CourtBookingUnavailabilityProvider>(),
			});

			return services;
		}
	}
}
