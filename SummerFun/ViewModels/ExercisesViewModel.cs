using System.Collections.ObjectModel;
using System.ComponentModel;
using SummerFun.Helper;
using SummerFun.Models;

namespace SummerFun.ViewModels
{
	public class ExercisesViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ExercisesViewModel()
		{
			Exercises = new ObservableCollection<ExerciseModel>(JSONHelper.LoadExercises());
		}
		public ObservableCollection<ExerciseModel> Exercises { get; set; }
	}
}
