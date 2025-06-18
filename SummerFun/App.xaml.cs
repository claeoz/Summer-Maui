using SummerFun.ViewModels;

namespace SummerFun
{
	public partial class App : Application
	{
		public static ExercisesViewModel ViewModelExercise { get; set; }
		public App()
		{
			ViewModelExercise = new ExercisesViewModel();
			InitializeComponent();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			return new Window(new AppShell());
		}
	}
}