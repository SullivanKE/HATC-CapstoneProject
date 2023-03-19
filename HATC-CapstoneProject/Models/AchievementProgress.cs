using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class AchievementProgress
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Criteria { get; set; }
		[Range(1, int.MaxValue, ErrorMessage = "Must be a positive number.")]
		public int Goal { get; set; }
        public int Progress { get; set; }
    }
}
