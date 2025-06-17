namespace SummerFun.Models
{
	public class RoutineModel
	{
		private string name;
		private List<Tuple<ExerciseModel, int>> exercises;

		public RoutineModel(string name, List<Tuple<ExerciseModel, int>> exercises)
		{
			this.name = name;
			this.exercises = exercises;
		}
		public string Name
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}
		public List<Tuple<ExerciseModel, int>> Exercises
		{
			get
			{
				return exercises;
			}
			set
			{
				exercises = value;
			}
		}
	}
}
