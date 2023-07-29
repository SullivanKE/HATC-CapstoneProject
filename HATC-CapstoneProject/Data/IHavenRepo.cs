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
        public Task<Rank?> GetRankAsync(int id);
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

        #region Players
        public Task<int> SavePlayerAsync(Player item);
        public Task<Player> GetPlayerAsync(string id);
        #endregion

        #region Characters
        public IQueryable<Character> CharacterAsync { get; }
        public Task<Character> GetCharacterAsync(int id);
        public Task<int> SaveCharacterAsync(Character item);
        public Task<List<Character>> GetAllCharactersAsync();
        #endregion

        #region Shop

        public Task<ShopItem> GetShopItemAsync(int id);
        public Task<int> SaveShopItemAsync(ShopItem item);
        /// <summary>
        /// Retrieve all the ShopItems stored in the database. Shop Items retrieved using this method include Rarity.
        /// </summary>
        /// <returns>a task containing a <see cref="List{ShopItem}"/></returns>
        public Task<List<ShopItem>> GetAllShopItemsAsync();

        /// <summary>
        /// Retrieve all the ShopItems from the database then apply the given criteria and search strign to the result set for filtering/searching.
        /// </summary>
        /// <param name="search"> <see langword="abstract"/>string search term to search the name and source fields of shop items for</param>
        /// <param name="criteria">a <see cref="Criteria"/> enum which may hold zero, one or more criteria as flags</param>
        /// <returns>a lsit of <see cref="ShopItem"/>s that fit the indicated criteria and contain the search string in either their name or source field.</returns>
        Task<List<ShopItem>> AdvancedShopSearch(string? search, Criteria criteria);
        #endregion
    }
}
