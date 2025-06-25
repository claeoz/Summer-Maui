namespace SummerFun.Models
{
	//i feed chat gpt the api sample response and had it generate the following model for convenience
	public class WeatherResult
	{
		public string Cod { get; set; }
		public int Message { get; set; }
		public int Cnt { get; set; }
		public List<ForecastItem> List { get; set; }
		public CityInfo City { get; set; }
	}

	public class ForecastItem
	{
		public long Dt { get; set; }
		public string Summery { get; set; }
		public MainWeatherData Main { get; set; }
		public List<WeatherCondition> Weather { get; set; }
		public CloudData Clouds { get; set; }
		public RainSnowData Rain { get; set; }
		public RainSnowData Snow { get; set; }
		public WindData Wind { get; set; }
		public int VisibilityDistance { get; set; }
		public string VisibilityUnit { get; set; }
		public double ProbabilityOfPrecipitation { get; set; }
		public string ProbabilityOfPrecipitationUnit { get; set; }
		public SysData Sys { get; set; }
		public string DtTxt { get; set; }
	}

	public class MainWeatherData
	{
		public double Temprature { get; set; }
		public double TempratureFeelsLike { get; set; }
		public double TempratureMin { get; set; }
		public double TempratureMax { get; set; }
		public string TempratureUnit { get; set; }
		public int Pressure { get; set; }
		public int SeaLevelPressure { get; set; }
		public int GroundLevelPressure { get; set; }
		public string PressureUnit { get; set; }
		public int Humidity { get; set; }
		public string HumidityUnit { get; set; }
		public double TempKf { get; set; }
	}

	public class WeatherCondition
	{
		public int Id { get; set; }
		public string Main { get; set; }
		public string Description { get; set; }
		public string Icon { get; set; }
	}

	public class CloudData
	{
		public int Cloudiness { get; set; }
		public string Unit { get; set; }
	}

	public class RainSnowData
	{
		public double Amount { get; set; }
		public string Unit { get; set; }
	}

	public class WindData
	{
		public double Speed { get; set; }
		public int Degrees { get; set; }
		public double GustSpeed { get; set; }
		public string SpeedUnit { get; set; }
	}

	public class SysData
	{
		public string PartOfDay { get; set; }
	}

	public class CityInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Coordinates Coord { get; set; }
		public string Country { get; set; }
		public int Population { get; set; }
		public int Timezone { get; set; }
		public long Sunrise { get; set; }
		public string SunriseTxt { get; set; }
		public long Sunset { get; set; }
		public string SunsetTxt { get; set; }
	}

	public class Coordinates
	{
		public double Lat { get; set; }
		public double Lon { get; set; }
	}
}
