using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class FactionCard
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public IEnumerable<FactionCardEntry>? FactionPoints { get; set; }
    }
}
