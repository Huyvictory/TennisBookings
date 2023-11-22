using Microsoft.Extensions.DependencyInjection.Extensions;

namespace TennisBookings.DependencyInjection
{
	public static class BookingRulesServiceCollectionExtenstions
	{
		public static IServiceCollection AddBookingRules(this IServiceCollection services)
		{
			services.AddSingleton<ICourtBookingRule, ClubIsOpenRule>();
			services.AddSingleton<ICourtBookingRule, MaxBookingLengthRule>();
			services.AddSingleton<ICourtBookingRule, MaxPeakTimeBookingLengthRule>();
			services.AddScoped<ICourtBookingRule, MemberBookingsMustNotOverlapRule>();
			services.AddScoped<ICourtBookingRule, MemberCourtBookingsMaxHoursPerDayRule>();
			services.AddScoped<ICourtBookingRule, BookingDateFromFutureRule>();
			services.TryAddScoped<IBookingRuleProcessor, BookingRuleProcessor>();

			return services;
		}
	}
}
