using HATC_CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HATC_CapstoneProject.Data
{
    public class SessionRepo : IHavenRepo
    {
        private HavenDbContext context;
        public SessionRepo(HavenDbContext context)
        {
            this.context = context;
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

        public Task<Object> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveItemAsync(Object session)
        {
            throw new NotImplementedException();
        }

        public Task<List<Object>> GetAllItemsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
