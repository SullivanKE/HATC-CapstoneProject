namespace HATC_CapstoneProject.Models
{
	public class DowntimeVM
	{
		public Downtime Dt { get; set; }
		public Dictionary<string, string>? CsvTables { get; set; }
		public List<bool>? TableHasHead { get; set; }
	}
}
