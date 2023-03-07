using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Rank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public string Color { get; set; }
    }
}
