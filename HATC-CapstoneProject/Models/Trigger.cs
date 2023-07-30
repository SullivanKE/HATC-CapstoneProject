namespace HATC_CapstoneProject.Models
{
    public class Trigger
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TriggerId { get; set; }
        public string Description { get; set; } = "";
        public string Accomidation { get; set; } = "";
    }
}
