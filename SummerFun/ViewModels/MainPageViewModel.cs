using System.ComponentModel;
using SummerFun.Helper;

namespace SummerFun.ViewModels
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public MainPageViewModel()
		{

		}
		public string Slogan
		{
			get
			{
				return DefaultHelper.RandomSlogan();
			}
		}
	}
}
