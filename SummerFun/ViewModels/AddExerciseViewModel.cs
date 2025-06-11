using System.ComponentModel;
using System.Windows.Input;
using SummerFun.Enums;
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
			exercises = new HashSet<ExerciseModel>();
			exercises = JSONHelper.LoadExercises();
			SaveCommand = new Command(async () => await OnSave());
			ExitCommand = new Command(async () => await OnExit());
		}
		private async Task OnSave()
		{
			string errorMessage = "";
			if (string.IsNullOrWhiteSpace(Name))
			{
				errorMessage += $"{Environment.NewLine}Please Enter A Name";
			}
			if (string.IsNullOrWhiteSpace(Description))
			{
				errorMessage += $"{Environment.NewLine}Please Enter A Description";
			}
			if (MusclesUsed.Count == 0)
			{
				errorMessage += $"{Environment.NewLine}Please Select A Muscle";
			}
			if (errorMessage == "")
			{
				ExerciseModel model = new ExerciseModel(this.Name, this.Description, this.UsedEquipment, this.MusclesUsed);
				exercises.Add(model);
				JSONHelper.SaveExercises(exercises);
				await Shell.Current.GoToAsync("///Exercises");
			}
			else
			{
				await Application.Current.MainPage.DisplayAlert("Missing Info", errorMessage, "OK");
			}
		}
		private async Task OnExit()
		{
			await Shell.Current.GoToAsync("///Exercises");
		}
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Equipment> EquipmentOptions
		{
			get
			{
				return Enum.GetValues(typeof(Equipment)).Cast<Equipment>().ToList();
			}
		}
		//got chat gpt to generate this to fix a persistant problem
		private IList<object> _selectedMuscleObjects = new List<object>();

		public IList<object> SelectedMuscleObjects
		{
			get => _selectedMuscleObjects;
			set
			{
				if (_selectedMuscleObjects != value)
				{
					_selectedMuscleObjects = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedMuscleObjects)));
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MusclesUsed)));
				}
			}
		}
		//
		public List<Muscles> MusclesOptions
		{
			get
			{
				return Enum.GetValues(typeof(Muscles)).Cast<Muscles>().ToList();
			}
		}
		public HashSet<Muscles> MusclesUsed
		{
			get
			{
				return SelectedMuscleObjects?.Cast<Muscles>().ToHashSet() ?? new HashSet<Muscles>();
			}
		}
		public Equipment UsedEquipment { get; set; }
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
		public ICommand SaveCommand { get; set; }
		public ICommand ExitCommand { get; set; }
	}
}
