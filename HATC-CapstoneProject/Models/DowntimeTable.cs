using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class DowntimeTable
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public Downtime DowntimeParent { get; set; }
        public bool IsComplication { get; set; } = false;
        public bool HasHead { get; set; }
        public IEnumerable<DowntimeTableRow> Table { get; set; }
    }
}
