using System.Text;

namespace HATC_CapstoneProject.Data
{
	public static class StringRandomizer
	{
		public static string RandomStr(string strIn)
		{
			// creating a StringBuilder object()
			StringBuilder str_build = new StringBuilder();
			Random random = new Random();

			string[] list = strIn.Split(" ");
			char letter;

			for (int i = 0; i < list.Length; i++)
			{
				int length = list[i].Length;
				for (int j = 0; j < length; j++)
				{
					double flt = random.NextDouble();
					int shift = Convert.ToInt32(Math.Floor(25 * flt));
					letter = Convert.ToChar(shift + 65);
					str_build.Append(letter);
				}
				if (i+1 != list.Length)
				{
					str_build.Append(' ');
				}
			}
			return str_build.ToString();
		}
	}
}
