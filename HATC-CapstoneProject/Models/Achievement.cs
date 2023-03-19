using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Achievement
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[Required(ErrorMessage = "Name is required")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Ranking is required")]
		public Rank Level { get; set; }
        public bool IsHidden { get; set; }
		public bool IsUnlocked { get; set; }
        public bool IsMasked { get; set; }
		public string Benefit { get; set; }
        
        public List<AchievementProgress> AchievementProgress { get; set; }
    }
}
