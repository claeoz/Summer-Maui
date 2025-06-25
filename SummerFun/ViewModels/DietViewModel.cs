using System.ComponentModel;

namespace SummerFun.ViewModels
{
	public class DietViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		//goals
		private int calorieGoal;
		private int proteinGoal;
		private int fatGoal;
		private int carbGoal;

		//current
		private int calorieCurrent;
		private int proteinCurrent;
		private int fatCurrent;
		private int carbCurrent;

		//temporary
		private int calorieTemp;
		private int proteinTemp;
		private int fatTemp;
		private int carbTemp;
		public DietViewModel()
		{
			calorieGoal = 2800;
			proteinGoal = 200;
			fatGoal = 90;
			carbGoal = 280;

			calorieCurrent = 0;
			proteinCurrent = 0;
			fatCurrent = 0;
			carbCurrent = 0;

			calorieTemp = 0;
			proteinTemp = 0;
			fatTemp = 0;
			carbTemp = 0;
		}

		public int CalorieGoal
		{
			get
			{
				return calorieGoal;
			}
			set
			{
				calorieGoal = value;
			}
		}
		public int ProteinGoal
		{
			get
			{
				return proteinGoal;
			}
			set
			{
				proteinGoal = value;
			}
		}
		public int FatGoal
		{
			get
			{
				return fatGoal;
			}
			set
			{
				fatGoal = value;
			}
		}
		public int CarbGoal
		{
			get
			{
				return carbGoal;
			}
			set
			{
				carbGoal = value;
			}
		}
		public int CalorieCurrent
		{
			get
			{
				return calorieCurrent;
			}
			set
			{
				calorieCurrent = value;
			}
		}
		public int ProteinCurrent
		{
			get
			{
				return proteinCurrent;
			}
			set
			{
				proteinCurrent = value;
			}
		}
		public int FatCurrent
		{
			get
			{
				return fatCurrent;
			}
			set
			{
				fatCurrent = value;
			}
		}
		public int CarbCurrent
		{
			get
			{
				return carbCurrent;
			}
			set
			{
				carbCurrent = value;
			}
		}
		public int CalorieTemp
		{
			get
			{
				return calorieTemp;
			}
			set
			{
				calorieTemp = value;
			}
		}
		public int ProteinTemp
		{
			get
			{
				return proteinTemp;
			}
			set
			{
				proteinTemp = value;
			}
		}
		public int FatTemp
		{
			get
			{
				return fatTemp;
			}
			set
			{
				fatTemp = value;
			}
		}
		public int CarbTemp
		{
			get
			{
				return carbTemp;
			}
			set
			{
				carbTemp = value;
			}
		}
	}
}
