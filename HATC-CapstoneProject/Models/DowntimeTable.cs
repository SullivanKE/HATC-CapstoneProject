namespace HATC_CapstoneProject.Models
{
    public class DowntimeTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Downtime DowntimeParent { get; set; }

        public string[][] Table { get; set; }
    }
}
