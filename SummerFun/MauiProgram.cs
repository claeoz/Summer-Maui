using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using SummerFun.Pages;
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
#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
