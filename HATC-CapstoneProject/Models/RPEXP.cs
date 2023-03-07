using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class RPEXP
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public Character Char { get; set; }
        public Trait TraitResolved { get; set; }
        public bool isResolved { get; set; }

        public enum Trait
        {
            PersonalityTrait1,
            PersonalityTrait2,
            Ideal,
            Bond,
            Flaw
        }

    }
}
