using SummerFun.ViewModels;

namespace SummerFun.Pages;

public partial class OptionsPage : ContentPage
{
	public OptionsPage()
	{
		InitializeComponent();
		BindingContext = new OptionsViewModel();
	}
}