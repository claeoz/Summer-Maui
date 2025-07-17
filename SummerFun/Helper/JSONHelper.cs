using System.Text.Json;
using SummerFun.Enums;
using SummerFun.Models;

namespace SummerFun.Helper
{
	public static class JSONHelper
	{
		private static string exercisePath = Path.Combine(FileSystem.AppDataDirectory, "Exercises.json");
		private static string optionsPath = Path.Combine(FileSystem.AppDataDirectory, "Options.json");
		private static ReadOnlySpan<byte> Utf8Bom => new byte[] { 0xEF, 0xBB, 0xBF };
		public static void CleanJsons()
		{
			File.Delete(exercisePath);
			File.Delete(optionsPath);
			SaveExercises(DefaultHelper.defaultSet);
			SaveOptions(DefaultHelper.defaultSettings);
		}
		/// <summary>
		/// clears exercise list
		/// </summary>
		public static void Reset()
		{
			File.Delete(exercisePath);
			SaveExercises(DefaultHelper.defaultSet);
		}
		/// <summary>
		/// Saves a exercise hashset to a json file
		/// </summary>
		/// <param name="exercises">a list of exercise</param>
		public static void SaveExercises(HashSet<ExerciseModel> exercises)
		{
			if (File.Exists(exercisePath))
			{
				File.Delete(exercisePath);
			}
			FileStream fileStream = File.Create(exercisePath);
			Utf8JsonWriter writer = new Utf8JsonWriter(fileStream);

			writer.WriteStartArray();
			foreach (ExerciseModel model in exercises)
			{
				writer.WriteStartObject();
				writer.WriteString("Name", model.Name);
				writer.WriteString("Description", model.Description);
				writer.WriteString("Equipment", model.EquipmentUsed.ToString());
				writer.WriteStartArray("Muscles");
				foreach (Muscles muscle in model.MuscleGroup)
				{
					writer.WriteStringValue(muscle.ToString());
				}
				writer.WriteEndArray();
				writer.WriteEndObject();
			}
			writer.WriteEndArray();
			writer.Flush();
			fileStream.Close();
		}
		/// <summary>
		/// Loads a list of exercises from exercise.json
		/// </summary>
		/// <returns>this is the list of exercises from the json</returns>
		public static HashSet<ExerciseModel> LoadExercises()
		{
			if (!File.Exists(exercisePath) || new FileInfo(exercisePath).Length == 0)
			{
				SaveExercises(DefaultHelper.defaultSet);
			}

			HashSet<ExerciseModel> exercises = new HashSet<ExerciseModel>();

			JsonReaderOptions options = new JsonReaderOptions
			{
				AllowTrailingCommas = true,
				CommentHandling = JsonCommentHandling.Skip
			};

			ReadOnlySpan<byte> jsonReadOnlySpan = File.ReadAllBytes(exercisePath);

			// Read past the UTF-8 BOM bytes if a BOM exists.
			if (jsonReadOnlySpan.StartsWith(Utf8Bom))
			{
				jsonReadOnlySpan = jsonReadOnlySpan.Slice(Utf8Bom.Length);
			}

			var reader = new Utf8JsonReader(jsonReadOnlySpan, options);

			// Temporary fields for each Exercise
			string Name = "";
			string Description = "";
			Equipment equipment = 0;
			HashSet<Muscles> muscles = new HashSet<Muscles>();

			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.StartObject)
				{
					// Reset fields for new Exercise
					Name = "";
					Description = "";
					equipment = 0;
					muscles = new HashSet<Muscles>();
				}
				else if (reader.TokenType == JsonTokenType.PropertyName)
				{
					string propertyName = reader.GetString();

					// Now read the value
					if (!reader.Read()) continue;

					switch (propertyName)
					{
						case "Name":
							Name = reader.GetString();
							break;

						case "Description":
							Description = reader.GetString();
							break;

						case "Equipment":
							equipment = FactoryHelper.StringToEquipment(reader.GetString());
							break;

						case "Muscles":
							if (reader.TokenType == JsonTokenType.StartArray)
							{
								while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
								{
									if (reader.TokenType == JsonTokenType.String)
									{
										muscles.Add(FactoryHelper.StringToMuscles(reader.GetString()));
									}
								}
							}
							break;

					}
				}
				else if (reader.TokenType == JsonTokenType.EndObject && Name != "")
				{
					// Finished reading one Exercise → add it
					ExerciseModel model = new ExerciseModel(Name, Description, equipment, muscles);
					exercises.Add(model);
				}
			}

			return exercises;
		}
		/// <summary>
		/// Loads the options settings from Options.json
		/// </summary>
		/// <returns>the settings from the Options.json file</returns>
		public static OptionsModel LoadOptions()
		{
			OptionsModel model = DefaultHelper.defaultSettings;
			if (!File.Exists(optionsPath) || new FileInfo(optionsPath).Length == 0)
			{
				SaveOptions(model);
				return model;
			}
			else
			{
				JsonReaderOptions options = new JsonReaderOptions
				{
					AllowTrailingCommas = true,
					CommentHandling = JsonCommentHandling.Skip
				};

				ReadOnlySpan<byte> jsonReadOnlySpan = File.ReadAllBytes(optionsPath);

				// Read past the UTF-8 BOM bytes if a BOM exists.
				if (jsonReadOnlySpan.StartsWith(Utf8Bom))
				{
					jsonReadOnlySpan = jsonReadOnlySpan.Slice(Utf8Bom.Length);
				}

				var reader = new Utf8JsonReader(jsonReadOnlySpan, options);

				while (reader.Read())
				{
					if (reader.TokenType == JsonTokenType.PropertyName)
					{
						string? propertyName = reader.GetString();
						if (propertyName == null)
						{
							continue;
						}
						// Now read the value
						if (!reader.Read()) continue;

						switch (propertyName)
						{
							case "OnlineMode":
								model.OnlineMode = reader.GetBoolean();
								break;
						}
					}
				}
			}
			return model;
		}
		public static void SaveOptions(OptionsModel model)
		{
			if (File.Exists(optionsPath))
			{
				File.Delete(optionsPath);
			}
			FileStream fileStream = File.Create(optionsPath);
			Utf8JsonWriter writer = new Utf8JsonWriter(fileStream);

			writer.WriteStartObject();
			writer.WriteBoolean("OnlineMode", model.OnlineMode);
			writer.WriteEndObject();
			writer.Flush();
			fileStream.Close();
		}
	}
}
