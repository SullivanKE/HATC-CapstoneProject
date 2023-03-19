using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Item : SessionItem
    {
		[Required(ErrorMessage = "Item Fate is required")]
		public string Fate { get; set; }
    }
}
