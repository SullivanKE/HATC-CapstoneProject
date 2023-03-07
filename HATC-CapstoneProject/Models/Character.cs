using HATC_CapstoneProject.Controllers;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Character
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public Player Player { get; set;  }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Exp { get; set; }
        public int Downtime { get; set; }
        public FactionCard FactionPoints { get; set; } = new FactionCard();
        public bool isRetired { get; set; } = false;
    }
}
