using HATC_CapstoneProject.Models;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace HATC_CapstoneProject.Data
{
    public interface IHavenRepo
    {
		#region Downtime
		public IQueryable<Downtime> DowntimeAsync { get; }
        public Task<Downtime> GetDowntimeAsync(int id);
        public Task<int> SaveDowntimeAsync(Downtime item);
        public Task<List<Downtime>> GetAllDowntimeAsync();
		#endregion

		#region Achievements
		public IQueryable<Achievement> AchievementAsync { get; }
		public Task<Achievement> GetAchievementAsync(int id);
		public Task<int> SaveAchievementAsync(Achievement item);
		public Task<List<Achievement>> GetAllAchievementsAsync();
		#endregion

		#region Ranks
		public IQueryable<Rank> RankAsync { get; }
		public Task<Rank> GetRankAsync(int id);
		public Task<int> SaveRankAsync(Rank item);
		public Task<List<Rank>> GetAllRanksAsync();
		#endregion

		#region Sessions
		public IQueryable<Session> SessionAsync { get; }
		public Task<Session> GetSessionAsync(int id);
		public Task<int> SaveSessionAsync(Session item);
		public Task<List<Session>> GetAllSessionsAsync();
		#endregion

		#region Factions
		public IQueryable<Faction> FactionAsync { get; }
		public Task<Faction> GetFactionAsync(int id);
		public Task<int> SaveFactionAsync(Faction item);
		public Task<List<Faction>> GetAllFactionsAsync();
		#endregion

	}
}
