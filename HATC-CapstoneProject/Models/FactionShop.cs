using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
	public class FactionShop
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public IEnumerable<StringListItem> List { get; set; }
	}
}
