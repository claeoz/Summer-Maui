using SummerFun.Enums;

namespace SummerFun.Models
{
	public class ExerciseModel
	{
		private string name;
		private string description;
		private HashSet<Muscles> muscleGroup;
		private Equipment equipmentUsed;

		public ExerciseModel(string name, string description, Equipment equipmentUsed)
		{
			this.name = name;
			this.description = description;
			this.equipmentUsed = equipmentUsed;
			this.muscleGroup = new HashSet<Muscles>();
		}

		public void AddMuscleGroup(Muscles muscle)
		{
			muscleGroup.Add(muscle);
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
		public string Description
		{
			get
			{
				return description;
			}
			set
			{
				description = value;
			}
		}
		public HashSet<Muscles> MuscleGroup
		{
			get
			{
				return muscleGroup;
			}
		}
		public Equipment EquipmentUsed
		{
			get
			{
				return equipmentUsed;
			}
			set
			{
				equipmentUsed = value;
			}
		}
	}
}
