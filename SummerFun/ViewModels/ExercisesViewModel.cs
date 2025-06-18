using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using SummerFun.Enums;
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
			ResetCommand = new Command(async () => await OnReset());
			SaveCommand = new Command(async () => await OnSave());
			ExitCommand = new Command(async () => await OnExit());
		}
		private async Task OnSave()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
		private async Task OnExit()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
		private async Task OnAddExercise()
		{
			await Shell.Current.GoToAsync(nameof(AddExercisePage));
		}
		private async Task OnReset()
		{
			JSONHelper.Reset();
			Exercises.Clear();
			HashSet<ExerciseModel> set = JSONHelper.LoadExercises();
			foreach (ExerciseModel model in set)
			{
				Exercises.Add(model);
			}
			Exercises = new ObservableCollection<ExerciseModel>(JSONHelper.LoadExercises());
		}
		private async Task OnEdit()
		{
			if (SelectedExercise != null)
			{
				//got chat gpts help with this
				await App.Current.MainPage.Navigation.PushAsync(new EditExercise(App.ViewModelExercise));
			}
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
		public List<Equipment> EquipmentOptions
		{
			get
			{
				return Enum.GetValues(typeof(Equipment)).Cast<Equipment>().ToList();
			}
		}
		public List<Muscles> MusclesOptions
		{
			get
			{
				return Enum.GetValues(typeof(Muscles)).Cast<Muscles>().ToList();
			}
		}
		public ObservableCollection<ExerciseModel> Exercises { get; set; }
		public ICommand AddExerciseCommand { get; set; }
		public ICommand EditCommand { get; set; }
		public ICommand DeleteCommand { get; set; }
		public ICommand ResetCommand { get; set; }
		public ICommand SaveCommand { get; set; }
		public ICommand ExitCommand { get; set; }
		public ExerciseModel SelectedExercise { get; set; }
	}
}
