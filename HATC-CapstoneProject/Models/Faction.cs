using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Faction
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public IEnumerable<NPC>? Members { get; set; }

        public IEnumerable<FactionShop> Shops { get; set; }
        public IEnumerable<FactionPerk> Perks { get; set; }
    }
}
