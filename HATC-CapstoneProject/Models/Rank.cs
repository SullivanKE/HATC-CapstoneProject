

namespace HATC_CapstoneProject.Models
{
    public class Rank
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        public string Name { get; set; } = "None";
        [Required(ErrorMessage = "Rank Level is required")]
        public int Level { get; set; }
        [Required(ErrorMessage = "Rank Color is required '#RRGGBB', AllowEmptyStrings = false", AllowEmptyStrings = false)]
        public string Color { get; set; } = default!;
        [Required(ErrorMessage = "Rank Background Color is required '#RRGGBB'", AllowEmptyStrings = false)]
        public string BgColor { get; set; } = default!;
        public Rarity Ranking
        {
            get => Enum.Parse<Rarity>(Name);
            set => Name = value.ToString();
        }

    }
}
