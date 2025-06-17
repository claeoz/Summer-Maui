using SummerFun.ViewModels;

namespace SummerFun.Pages;

public partial class Schedule : ContentPage
{
	public Schedule()
	{
		InitializeComponent();
		BindingContext = new ScheduleViewModel();
	}
}