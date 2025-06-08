using System.Collections.ObjectModel;
using System.ComponentModel;
using SummerFun.Enums;
using SummerFun.Models;

namespace SummerFun.ViewModels
{
	public class ExercisesViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		public ExercisesViewModel()
		{
			Exercises = new ObservableCollection<ExerciseModel>
			{
				new ExerciseModel
				(
					"Push-ups",
				"you start by laying flat on the floor with your stomach down then hoist your upper body on your palms while keeping your spine and legs perfectly straight you push your body up and down",
				Enums.Equipment.Body,
				new HashSet<Muscles>
				{
					Muscles.Pecs
				}
				),
				new ExerciseModel
				(
					"Sit-ups",
					"lay on the ground (id recommend a mat) with your feet but and shoulders touching the ground. you keep your feet firmly planted on the ground and proceed to sit up using only your abs",
					Enums.Equipment.Body,
					new HashSet<Muscles>
					{
						Muscles.Abs
					}
				)
			};
		}
		public ObservableCollection<ExerciseModel> Exercises { get; set; }
	}
}
