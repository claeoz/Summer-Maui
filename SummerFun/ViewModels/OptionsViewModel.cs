using System.ComponentModel;
using SummerFun.Models;

namespace SummerFun.ViewModels
{
	public class OptionsViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private OptionsModel options;
		public OptionsViewModel()
		{
			options = new OptionsModel(false);
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
