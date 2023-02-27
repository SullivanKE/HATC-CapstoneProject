using HATC_CapstoneProject.Controllers;

namespace HATC_CapstoneProject.Models
{
    public class Character
    {
        public int Id { get; set; }
        public AppUser Player { get; set;  }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Exp { get; set; }
        public int Downtime { get; set; }
        public FactionCard FactionPoints { get; set; }
        public bool isRetired { get; set; } = false;
    }
}
