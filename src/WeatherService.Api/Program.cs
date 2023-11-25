using TennisBookings.Shared.Weather;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IRandomWeatherForecaster, RandomWeatherForecaster>();

var app = builder.Build();

app.MapGet("/weather/{city}", async (string city, IRandomWeatherForecaster forecaster) =>
	{
		var forecast = await forecaster.GetCurrentWeatherAsync(city);

		return forecast.Weather;
	});

app.MapGet("/", () => "this is minimal api .net 6");

app.Run();
