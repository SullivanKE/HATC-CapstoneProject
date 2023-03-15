using HATC_CapstoneProject.Models;
using System.Text;
using System.Text.RegularExpressions;

namespace HATC_CapstoneProject.Data
{
	public static class StringMethods
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
		public static List<DowntimeTableRow> CsvSeparator(string input)
		{
			List<DowntimeTableRow> returnValue = new List<DowntimeTableRow>();

			List<string> rows = Regex.Split(input, "[\r\n]+").ToList();

			foreach(string row in rows)
			{
				List<string> strings = row.Split(",").ToList();
				DowntimeTableRow newRow = new DowntimeTableRow();
				for(int i = 0; i < strings.Count;i++)
				{
					TableListItem item = new TableListItem
					{
						Index = i,
						Item = strings[i]
					};
					newRow.Row.ToList().Add(item);
				}
				returnValue.Add(newRow);
			}


			return returnValue;
		}
	}
}
