namespace HATC_CapstoneProject.Models
{
    public class ShopItem : SessionItem
    {
        public string? PriceAdjustment { get; set; }
        public string? Source { get; set; }
        public Rank Rarity { get; set; } = new Rank();
        public string? BanReason { get; set; }
        public int ManualWeight { get; set; }
        public string? Notes { get; set; }
        public bool IsAttunement { get; set; }
        public bool IsShoppable { get; set; }
        public bool IsCraftable { get; set; }
        public string? LinkTo5eTools { get; set; }
    }
}
