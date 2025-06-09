using SummerFun.ViewModels;

namespace SummerFun.Pages
{
	public partial class Exercises : ContentPage
	{
		public Exercises()
		{
			InitializeComponent();
			BindingContext = new ExercisesViewModel();
		}
	}

}
