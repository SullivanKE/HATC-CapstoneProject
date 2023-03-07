using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
	public class DowntimeTableRow
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public IEnumerable<StringListItem> Row { get; set; }
	}
}
