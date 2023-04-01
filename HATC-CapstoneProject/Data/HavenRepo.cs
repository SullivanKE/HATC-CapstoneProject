using Microsoft.EntityFrameworkCore;
using HATC_CapstoneProject.Models;

namespace HATC_CapstoneProject.Data
{
	public class HavenRepo : IHavenRepo
	{
		private HavenDbContext context;
		public HavenRepo(HavenDbContext context)
		{
			this.context = context;
		}
		#region Downtime
		public IQueryable<Downtime> DowntimeAsync 
		{
			get
			{
				return context.Downtime
					.Include(downtime => downtime.Resources)
					.Include(downtime => downtime.Resolution)
					.Include(downtime => downtime.Achievements)
					.Include(downtime => downtime.Tables)
						.ThenInclude(tables => tables.Table)
							.ThenInclude(table => table.Row);
			}
		}
		public async Task<List<Downtime>> GetAllDowntimeAsync()
		{
			List<Downtime> downtimeList = await context.Downtime
					.Include(downtime => downtime.Resources)
					.Include(downtime => downtime.Resolution)
					.Include(downtime => downtime.Achievements)
					.Include(downtime => downtime.Tables)
						.ThenInclude(tables => tables.Table)
							.ThenInclude(table => table.Row)
					.OrderBy(downtime => downtime.Name)
					.ToListAsync();

			foreach(Downtime dt in downtimeList)
			{
				if (dt.Tables != null)
				{
					dt.Tables = dt.Tables.OrderBy(tables => tables.IsComplication);
				}
			}

			return downtimeList;
		}
		public async Task<Downtime> GetDowntimeAsync(int id)
		{
			Downtime downtime = await context.Downtime
				.Where(downtime => downtime.Id == id)
				.Include(downtime => downtime.Resources)
				.Include(downtime => downtime.Resolution)
				.Include(downtime => downtime.Achievements)
				.Include(downtime => downtime.Tables)
					.ThenInclude(tables => tables.Table)
						.ThenInclude(table => table.Row)
				.SingleOrDefaultAsync();

			if (downtime.Tables != null)
				downtime.Tables = downtime.Tables.OrderBy(tables => tables.IsComplication);

			return downtime;
		}
		public async Task<int> SaveDowntimeAsync(Downtime item)
		{
			context.Downtime.Add(item);
			return await context.SaveChangesAsync();
		}
		#endregion

		#region Achievements
		public IQueryable<Achievement> AchievementAsync
		{
			get
			{
				return context.Achievements
					.Include(achievement => achievement.Level)
					.Include(achievement => achievement.AchievementProgress);
			}
		}
		public async Task<List<Achievement>> GetAllAchievementsAsync()
		{
			List<Achievement> achievementList = await context.Achievements
					.Include(achievement => achievement.Level)
                    .Include(achievement => achievement.AchievementProgress)
                    .OrderBy(achievement => achievement.Name)
					.ToListAsync();

			return achievementList;
		}
		public async Task<Achievement> GetAchievementAsync(int id)
		{
			Achievement achievement = await context.Achievements
				.Where(achievement => achievement.Id == id)
				.Include(achievement => achievement.Level)
                .Include(achievement => achievement.AchievementProgress)
                .SingleOrDefaultAsync();

			return achievement;
		}
		public async Task<int> SaveAchievementAsync(Achievement item)
		{
			context.Achievements.Add(item);
			return await context.SaveChangesAsync();
		}
		#endregion

		#region Ranks
		public IQueryable<Rank> RankAsync
		{
			get
			{
				return context.Ranks;
			}
		}
		public async Task<List<Rank>> GetAllRanksAsync()
		{
			List<Rank> rankList = await context.Ranks
					.OrderBy(rank => rank.Level)
					.ToListAsync();

			return rankList;
		}
		public async Task<Rank> GetRankAsync(int id)
		{
			Rank rank = await context.Ranks
				.Where(rank => rank.Id == id)
				.SingleOrDefaultAsync();

			return rank;
		}
		public async Task<int> SaveRankAsync(Rank item)
		{
			context.Ranks.Add(item);
			return await context.SaveChangesAsync();
		}
		#endregion

		#region Factions
		public IQueryable<Faction> FactionAsync
		{
			get
			{
				return context.Factions
				.Include(faction => faction.Members)
				.Include(faction => faction.Members)
					.ThenInclude(npc => npc.AdventureHooks)
				.Include(faction => faction.Members)
					.ThenInclude(npc => npc.Interactions)
				.Include(faction => faction.Shops)
					.ThenInclude(shops => shops.List)
				.Include(faction => faction.Perks);
			}
		}
		public async Task<List<Faction>> GetAllFactionsAsync()
		{
			List<Faction> faction = await context.Factions
				.Include(faction => faction.Members)
				.Include(faction => faction.Members)
					.ThenInclude(npc => npc.AdventureHooks)
				.Include(faction => faction.Members)
					.ThenInclude(npc => npc.Interactions)
				.Include(faction => faction.Shops)
					.ThenInclude(shops => shops.List)
				.Include(faction => faction.Perks)
					.OrderBy(faction => faction.Name)
					.ToListAsync();

			return faction;
		}
		public async Task<Faction> GetFactionAsync(int id)
		{
			Faction faction = await context.Factions
				.Include(faction => faction.Members)
				.Include(faction => faction.Members)
					.ThenInclude(npc => npc.AdventureHooks)
				.Include(faction => faction.Members)
					.ThenInclude(npc => npc.Interactions)
				.Include(faction => faction.Shops)
					.ThenInclude(shops => shops.List)
				.Include(faction => faction.Perks)
				.Where(faction => faction.Id == id)
				.SingleOrDefaultAsync();

			return faction;
		}
		public async Task<int> SaveFactionAsync(Faction item)
		{
			context.Factions.Add(item);
			return await context.SaveChangesAsync();
		}
		#endregion

		#region Sessions
		public IQueryable<Session> SessionAsync
		{
			get
			{
				return context.Sessions
					.Include(sessions => sessions.Characters)
						.ThenInclude(character => character.Player)
					.Include(sessions => sessions.Characters)
						.ThenInclude(character => character.FactionPoints)
					.Include(sessions => sessions.GMCharacter)
						.ThenInclude(GMCharacter => GMCharacter.Player)
					.Include(sessions => sessions.GMCharacter)
						.ThenInclude(GMCharacter => GMCharacter.FactionPoints)
					.Include(sessions => sessions.RolePlayExp)
						.ThenInclude(RpExp => RpExp.Char)
					.Include(sessions => sessions.AdHocItems)
					.Include(sessions => sessions.CombatItems)
					.Include(sessions => sessions.Loot)
					.Include(sessions => sessions.Achievements)
						.ThenInclude(achievement => achievement.Achieve)
					.Include(sessions => sessions.FactionRenown)
					.Include(sessions => sessions.TreasureList);
			}
		}
		public Task<Session> GetSessionAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<int> SaveSessionAsync(Session item)
		{
			throw new NotImplementedException();
		}

		public Task<List<Session>> GetAllSessionsAsync()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Players
/*		public IQueryable<Rank> PlayerAsync
		{
			get
			{
				return context.Ranks;
			}
		}
		public async Task<List<Rank>> GetAllPlayersAsync()
		{
			List<Rank> rankList = await context.Ranks
					.OrderBy(rank => rank.Level)
					.ToListAsync();

			return rankList;
		}*/
		public async Task<Player> GetPlayerAsync(string id)
		{
			Player player = await context.Players
				.Include(player => player.Triggers)
				.Where(player => player.Id == id)
				.SingleOrDefaultAsync();

			return player;
		}
		public async Task<int> SavePlayerAsync(Player item)
		{
			context.Players.Add(item);
			return await context.SaveChangesAsync();
		}

		#endregion

		#region Characters
		public IQueryable<Character> CharacterAsync
		{
			get
			{
				return context.Characters
					.Include(c => c.Player)
						.ThenInclude(p => p.Triggers)
					.Include(c => c.FactionPoints)
						.ThenInclude(f => f.FactionPoints)
							.ThenInclude(fp => fp.Fac);
			}
		}
		public async Task<List<Character>> GetAllCharactersAsync()
		{
			List<Character> characters = await context.Characters
					.Include(c => c.Player)
						.ThenInclude(p => p.Triggers)
					.Include(c => c.FactionPoints)
						.ThenInclude(f => f.FactionPoints)
							.ThenInclude(fp => fp.Fac)
					.OrderBy(c => c.Player.UserName)
					.ToListAsync();

			return characters;
		}
		public async Task<Character> GetCharacterAsync(int id)
		{
			Character shopItem = await context.Characters
					.Include(c => c.Player)
						.ThenInclude(p => p.Triggers)
					.Include(c => c.FactionPoints)
						.ThenInclude(f => f.FactionPoints)
							.ThenInclude(fp => fp.Fac)
				.Where(c => c.Id == id)
				.SingleOrDefaultAsync();

			return shopItem;
		}
		public async Task<int> SaveCharacterAsync(Character item)
		{
			context.Characters.Add(item);
			return await context.SaveChangesAsync();
		}
		#endregion

		#region Shop
		public IQueryable<ShopItem> ShopAsync
		{
			get
			{
				return context.Shop
					.Include(shop => shop.Rarity);
			}
		}
		public async Task<List<ShopItem>> GetAllShopItemsAsync()
		{
			List<ShopItem> shopItems = await context.Shop
				.Include(shop => shop.Rarity)
					.OrderBy(shop => shop.Name)
					.ToListAsync();

			return shopItems;
		}
		public async Task<ShopItem> GetShopItemAsync(int id)
		{
			ShopItem shopItem = await context.Shop
				.Include(shop => shop.Rarity)
				.Where(shop => shop.Id == id)
				.SingleOrDefaultAsync();

			return shopItem;
		}
		public async Task<int> SaveShopItemAsync(ShopItem item)
		{
			context.Shop.Add(item);
			return await context.SaveChangesAsync();
		}
		#endregion
	}
}
