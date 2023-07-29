namespace HATC_CapstoneProject.ViewModels;

public class ShopVM
{
    public string? SearchString { get; set; } = string.Empty!;
    public List<ShopItem> Items { get; set; } = new();
    public Criteria SearchCriteria { get; set; } = new();
    public int SearchItemLow { get; set; }
    public int SearchItemHigh { get; set; }
    public int SearchCraftingLow { get; set; }
    public int SearchCraftingHigh { get; set; }
    public Dictionary<string, string> RarityColors { get; set; } = new();
    public Dictionary<Criteria, bool> CriteriaBoxes { get; set; } = new();

    public ShopVM()
    {
        var boxes = Enum.GetValues<Criteria>().ToList();
        boxes.Remove(Criteria.All);

        foreach (var box in boxes)
        {
            CriteriaBoxes.Add((Criteria)box, false);
        }
    }
}
