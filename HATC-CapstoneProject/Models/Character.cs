
namespace HATC_CapstoneProject.Models;

public class Character
{
    public int Id { get; set; }
    [Required(ErrorMessage = "A Player is required")]
    public Player Player { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? Image { get; set; }
    public int Exp { get; set; } = 0;
    public int Downtime { get; set; } = 0;
    public FactionCard FactionPoints { get; set; } = new FactionCard();
    public bool isRetired { get; set; } = false;
}
