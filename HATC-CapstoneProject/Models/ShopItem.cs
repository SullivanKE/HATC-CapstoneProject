using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class ShopItem : SessionItem
    {
		public string? PriceAdjustment { get; set; }
        public string? Source { get; set;}
        public Rank Rarity { get; set; } = new Rank();
        public string? BanReason { get; set; }
        public int ManualWeight { get; set; }
        public string? Notes { get; set; }
        public bool isAttunement { get; set; }
        public bool isShoppable { get; set; }
        public bool isCraftable { get; set; }
        public string? LinkTo5eTools { get; set; }
    }
}
