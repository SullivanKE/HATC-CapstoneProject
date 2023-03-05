namespace HATC_CapstoneProject.Models
{
    public class Downtime
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StringListItem> Resources { get; set; }
        public IEnumerable<StringListItem> Resolution { get; set; }
        public IEnumerable<Achievement> Achievements { get; set;}
        public bool Status { get; set; }
    }
}
