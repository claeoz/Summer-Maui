using System.ComponentModel;
using SummerFun.Enums;
using SummerFun.Models;

namespace SummerFun.ViewModels
{
	public class ScheduleViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private RoutineModel mondayRoutine;
		private RoutineModel tuesdayRoutine;
		private RoutineModel wednesdayRoutine;
		private RoutineModel thursdayRoutine;
		private RoutineModel fridayRoutine;
		private RoutineModel saturdayRoutine;
		private RoutineModel sundayRoutine;

		public ScheduleViewModel()
		{
			ExerciseModel Squats = new ExerciseModel(
				"Squats", "Rest a barbell upon the back of your neck then squat down into a sitting position then hoist yourself up",
				Equipment.Barbell,
				new HashSet<Enums.Muscles>()
				{
					Muscles.Quads
				}
			);

			ExerciseModel CalfRaises = new ExerciseModel(
				"Calf Raises",
				"stand on slight elevated surface with your heels hanging of the back and raise you heels off the ground with a dumbell in each hand",
				Equipment.Dumbell,
				new HashSet<Muscles>()
				{
					Muscles.Calves
				}
			);

			ExerciseModel BarbellSitUps = new ExerciseModel(
				"Barbell Sit Ups",
				"Lay down on a bench and lock your legs around the benches legs and hold the barbell right bellow the chin and proceed to do situps",
				Equipment.Barbell,
				new HashSet<Enums.Muscles>()
				{
					Muscles.Abs
				}
			);
			RoutineModel legday = new RoutineModel(
				"Magnus The Swoles Legday",
				new List<Tuple<ExerciseModel, int>>()
				{
					new Tuple<ExerciseModel, int>(Squats, 20),
					new Tuple<ExerciseModel, int>(Squats, 10),
					new Tuple<ExerciseModel, int>(Squats, 5),
					new Tuple<ExerciseModel, int>(Squats, 1),

					new Tuple<ExerciseModel, int>(CalfRaises, 20),
					new Tuple<ExerciseModel, int>(CalfRaises, 10),
					new Tuple<ExerciseModel, int>(CalfRaises, 5),

					new Tuple<ExerciseModel, int>(BarbellSitUps, 20),
					new Tuple<ExerciseModel, int>(BarbellSitUps, 10),
					new Tuple<ExerciseModel, int>(BarbellSitUps, 5)
				});
		}

	}
}
