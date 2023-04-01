using HATC_CapstoneProject.Controllers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Character
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "A Player is required")]
		public Player Player { get; set;  }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Exp { get; set; } = 0;
        public int Downtime { get; set; } = 0;
        public FactionCard FactionPoints { get; set; } = new FactionCard();
        public bool isRetired { get; set; } = false;
    }
}
