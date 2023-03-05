namespace HATC_CapstoneProject.Models
{
    public class FactionCard
    {
        public int Id { get; set; }
        public IEnumerable<FactionCardEntry>? FactionPoints { get; set; }
    }
}
