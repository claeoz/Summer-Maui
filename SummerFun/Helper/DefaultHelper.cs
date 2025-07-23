using SummerFun.Enums;
using SummerFun.Models;

namespace SummerFun.Helper
{
	public static class DefaultHelper
	{
		/// <summary>
		/// the default offline exercise list
		/// </summary>
		public static HashSet<ExerciseModel> defaultSet = new HashSet<ExerciseModel>
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
				),
				new ExerciseModel(
					"Barbell Squat",
					"A compound movement that strengthens the legs and glutes using a barbell.",
					Equipment.Barbell,
					new HashSet<Muscles>
					{
						Muscles.Quads,
						Muscles.Glutes,
						Muscles.Hamstrings
					}
				),

				new ExerciseModel(
					"Lat Pulldown",
					"An upper-body pull exercise that targets the latissimus dorsi and biceps.",
					Equipment.Machine,
					new HashSet<Muscles>
					{
						Muscles.Lats,
						Muscles.Biceps
					}
				)
		};
		public static OptionsModel defaultSettings = new OptionsModel(false);

		public static List<string> Slogans = new List<string>
		{
			"RAAAUUGH!!!",
			"GET TO DA CHOPPAH",
			"I may be out of spells slots but im not out of options",
			"I CAST ... BRICK",
			"Not all who wander is lost, but i sure as heck am",
			"do not stray from the whey",
			"Protein Protein Protein Protein Protein Protein Protein Protein Protein Protein Protein Protein Protein Protein Protein Protein"
		};
		public static string RandomSlogan()
		{
			Random random = new Random();
			int index = random.Next(Slogans.Count - 1);
			string slogan = Slogans[index];
			return slogan;
		}
	}
}
