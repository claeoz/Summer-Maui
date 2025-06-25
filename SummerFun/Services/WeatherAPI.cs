using System.Diagnostics;
using System.Text.Json;
using SummerFun.Models;

namespace SummerFun.Services
{
	public class WeatherAPI
	{
		private readonly HttpClient client;

		public WeatherAPI(HttpClient httpClient)
		{
			client = httpClient;
		}
		public async Task<WeatherResult?> GetWeather(string city)
		{
			try
			{
				string encodedCity = Uri.EscapeDataString(city);
				HttpResponseMessage response = await client.GetAsync($"weather/{encodedCity}");

				if (!response.IsSuccessStatusCode)
				{
					return null;
				}
				string json = await response.Content.ReadAsStringAsync();

				JsonSerializerOptions options = new JsonSerializerOptions
				{
					PropertyNameCaseInsensitive = true,
				};

				WeatherResult? result = JsonSerializer.Deserialize<WeatherResult>(json, options);

				return result;
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Weather API error: {ex.Message}");
				return null;
			}
		}
	}
}
