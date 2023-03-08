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
					.Include(achievement => achievement.Level);
			}
		}
		public async Task<List<Achievement>> GetAllAchievementsAsync()
		{
			List<Achievement> achievementList = await context.Achievements
					.Include(achievement => achievement.Level)
					.OrderBy(achievement => achievement.Name)
					.ToListAsync();

			return achievementList;
		}
		public async Task<Achievement> GetAchievementAsync(int id)
		{
			Achievement achievement = await context.Achievements
				.Where(achievement => achievement.Id == id)
				.Include(achievement => achievement.Level)
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


	}
}
