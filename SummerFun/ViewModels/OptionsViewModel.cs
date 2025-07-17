using System.ComponentModel;
using SummerFun.Helper;
using SummerFun.Models;

namespace SummerFun.ViewModels
{
	public class OptionsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private OptionsModel options;
		public OptionsViewModel()
		{
			JSONHelper.CleanJsons();
			options = JSONHelper.LoadOptions();
		}
		public OptionsModel Options
		{
			get
			{
				return options;
			}
			set
			{
				options = value;
			}
		}
	}
}
