using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Achievement
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public string Benefit { get; set; }
        public string Criteria { get; set; }
        public int Goal { get; set; }
        public int Progress { get; set; }
    }
}
