using SummerFun.ViewModels;

namespace SummerFun.Pages;

public partial class AddExercisePage : ContentPage
{
	public AddExercisePage()
	{
		InitializeComponent();
		BindingContext = new AddExerciseViewModel();
	}
}