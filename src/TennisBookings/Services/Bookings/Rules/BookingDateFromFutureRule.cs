namespace TennisBookings.Services.Bookings.Rules
{
	public class BookingDateFromFutureRule : ICourtBookingRule
	{
		public async Task<bool> CompliesWithRuleAsync(CourtBooking booking)
		{
			var isBookingCourtFromFuture = DateTime.Compare(booking.StartDateTime, DateTime.Now.AddDays(-2));

			if (isBookingCourtFromFuture <= 0)
			{
				return false;
			}
			return true;
		}

		public string ErrorMessage => "The booking is not from future, please try again";
	}
}
