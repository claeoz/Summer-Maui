using SummerFun.Pages;

namespace SummerFun
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(AddExercisePage), typeof(AddExercisePage));
		}
	}
}
