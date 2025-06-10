using System.ComponentModel;
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
		public List<Muscles> MusclesOptions
		{
			get
			{
				return Enum.GetValues(typeof(Muscles)).Cast<Muscles>().ToList();
			}
		}
		public List<Muscles> MusclesUsed { get; set; }
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
	}
}
