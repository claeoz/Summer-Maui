using System.ComponentModel;
using System.Windows.Input;
using SummerFun.Models;
using SummerFun.Services;

namespace SummerFun.ViewModels
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		private readonly WeatherAPI weatherAPI;
		public event PropertyChangedEventHandler PropertyChanged;
		private string city;
		private string summary;

		public MainPageViewModel(WeatherAPI weatherAPI)
		{
			this.weatherAPI = weatherAPI;
			city = "Tokyo";
			GetWeatherCommand = new Command(async () => await GetWeather());

			//chat gpt called this a fire and forget if youre reading this mr presley i wouldnt mind your input/opinion/explanation
			Task _ = GetWeather();
		}

		private async Task GetWeather()
		{
			WeatherResult? result = await weatherAPI.GetWeather(City);

			if (result?.List?.Any() == true)
			{
				ForecastItem first = result.List[0];
				WeatherCondition firstCondition = first.Weather.First();

				string cityName = City;
				string weatherDescription = firstCondition.Description;
				double temperature = first.Main.Temprature;

				Summary = $"{cityName}: {weatherDescription}, {temperature}K";
			}
			else
			{
				Summary = "Weather data unavailable.";
			}
		}

		public string City
		{
			get
			{
				return city;
			}
			set
			{
				this.city = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(City)));
			}
		}
		public string Summary
		{
			get
			{
				return summary;
			}
			set
			{
				this.summary = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Summary)));
			}
		}
		public ICommand GetWeatherCommand { get; }
	}
}
