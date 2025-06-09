using System.ComponentModel;
using SummerFun.Helper;
using SummerFun.Models;

namespace SummerFun.ViewModels
{
	public class AddExerciseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ExerciseModel exercise;
		private HashSet<ExerciseModel> exercises;

		public AddExerciseViewModel()
		{
			exercises = JSONHelper.LoadExercises();
		}

		public ExerciseModel Exercise
		{
			get
			{
				return exercise;
			}
			set
			{
				exercise = value;
			}
		}
	}
}
