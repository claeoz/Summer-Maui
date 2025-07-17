using SummerFun.Helper;
namespace SummerFun.Models
{
	public class OptionsModel
	{
		private bool onlineMode;
		public OptionsModel(bool onlineMode)
		{
			this.OnlineMode = onlineMode;
		}
		public bool OnlineMode
		{
			get
			{
				return onlineMode;
			}
			set
			{
				onlineMode = value;
				JSONHelper.SaveOptions(this);
			}
		}
	}
}
