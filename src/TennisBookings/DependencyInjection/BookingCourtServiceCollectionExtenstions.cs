using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection
{
	public static class BookingCourtServiceCollectionExtenstions
	{
		public static IServiceCollection BookingCourtServices(this IServiceCollection services)
		{
			services.TryAddScoped<ICourtBookingService, CourtBookingService>();
			services.TryAddSingleton<IUtcTimeService, TimeService>();

			services.TryAddScoped<IBookingService, BookingService>();
			services.TryAddScoped<ICourtService, CourtService>();

			services.TryAddScoped<ICourtBookingManager, CourtBookingManager>();
			services.TryAddSingleton<INotificationService, EmailNotificationService>();

			return services;
		}
	}
}
