namespace HATC_CapstoneProject.Models
{
    public class FactionCard
    {
        public int Id { get; set; }
        public Dictionary<Faction, int>? FactionPoints { get; set; }
    }
}
