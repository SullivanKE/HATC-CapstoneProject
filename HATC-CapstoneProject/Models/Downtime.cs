using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Downtime
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<StringListItem>? Resources { get; set; }
        public IEnumerable<StringListItem>? Resolution { get; set; }
        public IEnumerable<Achievement>? Achievements { get; set;}
        public bool Status { get; set; }
        public IEnumerable<DowntimeTable>? Tables { get; set; }

	}
}
