using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Session
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public DateTime RealDate { get; set; }
        public string InGameDate { get; set; } = string.Empty;
        public Character GMCharacter { get; set; } = new Character();
        public int DowntimeReward { get; set; }
        public IEnumerable<Character> Characters { get; set; } = Enumerable.Empty<Character>();
        public IEnumerable<RPEXP> RolePlayExp { get; set; } = Enumerable.Empty<RPEXP>();
        public IEnumerable<SessionItem> AdHocItems { get; set; } = Enumerable.Empty<SessionItem>();
        public IEnumerable<Monster> CombatItems { get; set; } = Enumerable.Empty<Monster>();
        public IEnumerable<Item> Loot { get; set; } = Enumerable.Empty<Item>();
        public IEnumerable<AchievementAdvancement> Achievements { get; set; } = Enumerable.Empty<AchievementAdvancement>();
        public IEnumerable<FactionCard> FactionRenown { get; set; } = Enumerable.Empty<FactionCard>();
        public IEnumerable<SessionItem> TreasureList { get; set; } = Enumerable.Empty<SessionItem>();
    }
}
