using SummerFun.Enums;

namespace SummerFun.Helper
{
	public static class FactoryHelper
	{
		public static Equipment StringToEquipment(string word)
		{
			switch (word.ToLower())
			{
				case "dumbell":
					return Equipment.Dumbell;
				case "barbell":
					return Equipment.Barbell;
				case "kettlebell":
					return Equipment.Kettlebell;
				case "cardio":
					return Equipment.Cardio;
				case "body":
					return Equipment.Body;
				case "machine":
					return Equipment.Machine;
				default:
					throw new ArgumentException($"unable to process {word}");

			}
		}
		public static Muscles StringToMuscles(string word)
		{
			switch (word.ToLower())
			{
				case "biceps":
					return Muscles.Biceps;
				case "triceps":
					return Muscles.Triceps;
				case "pecs":
					return Muscles.Pecs;
				case "lats":
					return Muscles.Lats;
				case "traps":
					return Muscles.Traps;
				case "delts":
					return Muscles.Delts;
				case "forearms":
					return Muscles.Forearms;
				case "abs":
					return Muscles.Abs;
				case "obliques":
					return Muscles.Obliques;
				case "glutes":
					return Muscles.Glutes;
				case "quads":
					return Muscles.Quads;
				case "hamstrings":
					return Muscles.Hamstrings;
				case "calves":
					return Muscles.Calves;
				case "cardio":
					return Muscles.Cardio;
				default:
					throw new ArgumentException($"unable to process {word}");
			}
		}
	}
}
