using Microsoft.Extensions.Options;
using TennisBookings.Configuration;

namespace TennisBookings.Tests.Pages;

public class IndexTests
{
	[Fact]
	public async Task ReturnsExpectedViewModel_WhenWeatherIsSun()
	{
		var sut = new IndexModel(new SunForcaster(), NullLogger<IndexModel>.Instance, new EnabledConfig());

		await sut.OnGet();

		Assert.Contains("It's sunny right now.", sut.WeatherDescription);
	}

	[Fact]
	public async Task ReturnsExpectedViewModel_WhenWeatherIsRain()
	{
		var sut = new IndexModel(new RainForcaster(), NullLogger<IndexModel>.Instance, new EnabledConfig());

		await sut.OnGet();

		Assert.Contains("We're sorry but it's raining here.", sut.WeatherDescription);
	}

	private class EnabledConfig : IOptionsSnapshot<FeatureConfiguration>
	{
		public FeatureConfiguration Value => new FeatureConfiguration { EnableWeatherForecast = true };

		public FeatureConfiguration Get(string name)
		{
			throw new NotImplementedException();
		}
	}

	private class SunForcaster : IRandomWeatherForecaster
	{
		public Task<WeatherResult> GetCurrentWeatherAsync(string city)
		{
			return Task.FromResult(new WeatherResult
			{
				City = city,
				Weather = new WeatherCondition
				{
					Summary = "Sun"
				}
			});
		}
	}

	private class RainForcaster : IRandomWeatherForecaster
	{
		public Task<WeatherResult> GetCurrentWeatherAsync(string city)
		{
			return Task.FromResult(new WeatherResult
			{
				City = city,
				Weather = new WeatherCondition
				{
					Summary = "Rain"
				}
			});
		}
	}
}
