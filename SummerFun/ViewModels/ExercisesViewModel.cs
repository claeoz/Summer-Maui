using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SummerFun.Enums;
using SummerFun.Helper;
using SummerFun.Models;
using SummerFun.Pages;

namespace SummerFun.ViewModels
{
	public partial class ExercisesViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private ExerciseModel selectedExercise;
		public ExercisesViewModel()
		{
			Exercises = new ObservableCollection<ExerciseModel>(JSONHelper.LoadExercises());
		}
		[RelayCommand]
		private async Task OnSave()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
		[RelayCommand]
		private async Task OnExit()
		{
			await App.Current.MainPage.Navigation.PopAsync();
		}
		[RelayCommand]
		private async Task OnAddExercise()
		{
			await Shell.Current.GoToAsync(nameof(AddExercisePage));
		}
		[RelayCommand]
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
		[RelayCommand]
		private async Task OnEdit()
		{
			if (SelectedExercise != null)
			{
				//got chat gpts help with this
				await App.Current.MainPage.Navigation.PushAsync(new EditExercise(App.ViewModelExercise));
			}
		}
		[RelayCommand]
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
		public ExerciseModel SelectedExercise
		{
			get
			{
				return selectedExercise;
			}
			set
			{
				if (selectedExercise != value)
				{
					selectedExercise = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedExercise)));
				}
			}
		}
	}
}
