using SummerFun.Enums;

namespace SummerFun.Models
{
	public class ExerciseModel
	{
		private string name;
		private string description;
		private HashSet<Muscles> muscleGroup;
		private Equipment equipmentUsed;
		/// <summary>
		/// The data template for an exercise
		/// </summary>
		/// <param name="Name">what the exercise is called</param>
		/// <param name="Description"> a blurb describing the exercise</param>
		/// <param name="EquipmentUsed">what is required to do the exercise</param>
		public ExerciseModel(string Name, string Description, Equipment EquipmentUsed, HashSet<Muscles> MuscleGroup)
		{
			this.name = Name;
			this.description = Description;
			this.equipmentUsed = EquipmentUsed;
			this.muscleGroup = MuscleGroup;
		}

		/// <summary>
		/// name of the exercise
		/// </summary>
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

		/// <summary>
		/// the blurb for the exercise
		/// </summary>
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

		/// <summary>
		/// lists all the muscles affected by the exercise
		/// </summary>
		public HashSet<Muscles> MuscleGroup
		{
			get
			{
				return muscleGroup;
			}
		}

		/// <summary>
		/// the equipment used for the exercise
		/// </summary>
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
