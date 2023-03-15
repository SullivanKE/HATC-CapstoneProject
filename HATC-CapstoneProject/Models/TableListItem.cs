using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
	public class TableListItem
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public int Index { get; set; }
		public string Item { get; set; }
	}
}
