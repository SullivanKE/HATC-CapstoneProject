using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class NPC
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public IEnumerable<StringListItem>? Stats { get; set; }
        public string? Personality { get; set; }
        public string? Motivation { get; set; }
        public string? Apperance { get; set; }
        public string? Background { get; set; }
        public string? Quirk { get; set; }
        public string? Interactions { get; set; }
        public IEnumerable<StringListItem>? AdventureHooks { get; set; }
        public string? Notes { get; set; }
    }
}
