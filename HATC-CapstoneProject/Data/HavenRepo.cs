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
					.OrderByDescending(downtime => downtime.Name)
					.ToListAsync();
			return downtimeList;
		}

		public async Task<Downtime> GetDowntimeAsync(int id)
		{
			Downtime downtimeList = await context.Downtime
				.Where(downtime => downtime.Id == id)
				.Include(downtime => downtime.Resources)
				.Include(downtime => downtime.Resolution)
				.Include(downtime => downtime.Achievements)
				.Include(downtime => downtime.Tables)
					.ThenInclude(tables => tables.Table)
						.ThenInclude(table => table.Row)
				.SingleOrDefaultAsync();
			return downtimeList;
		}

		

		public async Task<int> SaveDowntimeAsync(Downtime item)
		{
			if (item.GetType() == typeof(Downtime))
			{
				Downtime downtime = (Downtime)item;

				context.Downtime.Add(downtime);
			}
			return await context.SaveChangesAsync();
		}

		public IQueryable<Object> ItemsAsync
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
	}
}
