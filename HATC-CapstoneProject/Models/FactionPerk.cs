using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class FactionPerk
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public int Renown { get; set; }
        public bool IsLocked { get; set; } = false;
        public string Item { get; set; }
    }
}
