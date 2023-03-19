using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Rank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Rank Level is required")]
		public int Level { get; set; }
		[Required(ErrorMessage = "Rank Color is required '#RRGGBB'")]
		public string Color { get; set; }
		[Required(ErrorMessage = "Rank Background Color is required '#RRGGBB'")]
		public string BgColor { get; set; }
    }
}
