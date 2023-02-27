namespace HATC_CapstoneProject.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public IEnumerable<NPC>? Members { get; set; }
    }
}
