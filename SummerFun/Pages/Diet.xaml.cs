using SummerFun.ViewModels;

namespace SummerFun.Pages;

public partial class Diet : ContentPage
{
	public Diet()
	{
		InitializeComponent();
		BindingContext = new DietViewModel();
	}
}