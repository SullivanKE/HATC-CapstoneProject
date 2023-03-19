using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class FactionPerk
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Renown is required")]
		public int Renown { get; set; }
        public bool IsLocked { get; set; } = false;
		[Required(ErrorMessage = "Item Name is required")]
		public string Item { get; set; }
    }
}
