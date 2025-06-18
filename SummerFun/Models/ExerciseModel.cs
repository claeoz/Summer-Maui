using System.ComponentModel;
using SummerFun.Enums;
using SummerFun.Helper;

namespace SummerFun.Models
{
	public class ExerciseModel : INotifyPropertyChanged
	{
		private string name;
		private string description;
		private HashSet<Muscles> muscleGroup;
		private Equipment equipmentUsed;
		public event PropertyChangedEventHandler PropertyChanged;
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

		protected void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public string MusclesAsString
		{
			get
			{
				return string.Join(", ", this.muscleGroup);
			}
		}

		public string EquipmentAsString
		{
			get
			{
				return equipmentUsed.ToString();
			}
			set
			{
				EquipmentUsed = FactoryHelper.StringToEquipment(value);
			}
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
				if (equipmentUsed != value)
				{
					equipmentUsed = value;
					OnPropertyChanged(nameof(EquipmentUsed));
				}
			}
		}
	}
}
