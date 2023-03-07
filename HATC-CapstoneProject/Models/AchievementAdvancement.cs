using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class AchievementAdvancement
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public Achievement Achieve { get; set; }
        public int Advancement { get; set; }
    }
}
