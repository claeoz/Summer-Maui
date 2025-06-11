using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using SummerFun.Helper;
using SummerFun.Models;
using SummerFun.Pages;

namespace SummerFun.ViewModels
{
	public class ExercisesViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ExercisesViewModel()
		{
			Exercises = new ObservableCollection<ExerciseModel>(JSONHelper.LoadExercises());
			AddExerciseCommand = new Command(async () => await OnAddExercise());
		}
		private async Task OnAddExercise()
		{
			await Shell.Current.GoToAsync(nameof(AddExercisePage));
		}
		public ObservableCollection<ExerciseModel> Exercises { get; set; }
		public ICommand AddExerciseCommand { get; set; }
		public ExerciseModel SelectedExercise { get; set; }
	}
}
