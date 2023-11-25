using Microsoft.AspNetCore.Identity;

namespace TennisBookings.Middleware
{
	public class LastRequestMiddlewareFactory : IMiddleware
	{
		private readonly UserManager<TennisBookingsUser> _userManager;
		private readonly IUtcTimeService _utcTimeService;

		public LastRequestMiddlewareFactory(
			UserManager<TennisBookingsUser> userManager,
			IUtcTimeService utcTimeService
			)
		{
			_userManager = userManager;
			_utcTimeService = utcTimeService;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			if (context.User.Identity is not null && context.User.Identity.IsAuthenticated)
			{
				var user = await _userManager.FindByEmailAsync(context.User.Identity.Name);

				if (user is not null)
				{
					user.LastRequestUtc = _utcTimeService.CurrentUtcDateTime;
					await _userManager.UpdateAsync(user);
				}
			}

			await next(context);
		}
	}
}

