using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
	public class FactionShop
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Price is required")]
		public int Cost { get; set; }
		public IEnumerable<StringListItem> List { get; set; }
	}
}
