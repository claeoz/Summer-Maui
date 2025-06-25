using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SummerFun.Pages;
using SummerFun.Services;
using SummerFun.ViewModels;


namespace SummerFun
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{

			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()

				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});
			builder.Services.AddTransient<ExercisesViewModel>();
			builder.Services.AddTransient<AddExercisePage>();
			builder.Services.AddTransient<Diet>();
			builder.Services.AddTransient<EditExercise>();
			builder.Services.AddTransient<Exercises>();
			builder.Services.AddTransient<MainPageViewModel>();
			builder.Services.AddHttpClient<WeatherAPI>(client =>
			{
				client.BaseAddress = new Uri("https://weather-api167.p.rapidapi.com/");
				client.DefaultRequestHeaders.Add("X-RapidAPI-Key", "5857916cc7msha804731fd28ef70p12dae0jsn06ec0f339169");
				client.DefaultRequestHeaders.Add("X-RapidAPI-Host", "weather-api167.p.rapidapi.com");
			});
#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
