using SummerFun.ViewModels;

namespace SummerFun.Pages;

public partial class EditExercise : ContentPage
{
	public EditExercise(ExercisesViewModel exercisesViewModel)
	{
		InitializeComponent();
		BindingContext = exercisesViewModel;
		//BindingContext = App.ViewModelExercise;
	}
}