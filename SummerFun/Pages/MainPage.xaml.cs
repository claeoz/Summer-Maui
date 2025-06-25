using SummerFun.ViewModels;
namespace SummerFun.Pages
{
	public partial class MainPage : ContentPage
	{
		public MainPage(MainPageViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}