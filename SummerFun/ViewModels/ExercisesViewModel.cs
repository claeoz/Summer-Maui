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
			EditCommand = new Command(async () => await OnEdit());
			DeleteCommand = new Command(async () => await OnDelete());
		}
		private async Task OnAddExercise()
		{
			await Shell.Current.GoToAsync(nameof(AddExercisePage));
		}
		private async Task OnEdit()
		{

		}
		private async Task OnDelete()
		{
			if (SelectedExercise != null)
			{
				Exercises.Remove(SelectedExercise);
				JSONHelper.SaveExercises(Exercises.ToHashSet());
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Nothing Selected", "Please select an object to delete.", "OK");
			}
		}
		public ObservableCollection<ExerciseModel> Exercises { get; set; }
		public ICommand AddExerciseCommand { get; set; }
		public ICommand EditCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ExerciseModel SelectedExercise { get; set; }
	}
}
