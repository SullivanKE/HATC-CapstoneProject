using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace HATC_CapstoneProject.Data
{
    public class SeedData
    {
        public static void Seed(HavenDbContext context, IServiceProvider provider)
        {
            if (!context.Sessions.Any())
            {
                // Generate users
                var userManager = provider.GetRequiredService<UserManager<Player>>();

                //TODO: Use user secrets to hide the password
                const string PASSWORD = "root";
                Player user1 = new Player
                {
                    UserName = "root"
                };
                userManager.CreateAsync(user1, PASSWORD);

                //Generate character
                Character character = new Character
                {
                    Id = 0,
                    Player = user1,
                    Exp = 0,
                    Downtime = 0
                };
                context.Characters.Add(character);
                context.SaveChanges();

                // Generate Sessions
                Session session;
                session = new Session
                {
                    Id = 0,
                    GMCharacter = character,
                    RealDate = DateTime.Now,
                    InGameDate = "Jan 1, Year 1",
                    DowntimeReward = 0
                };
				context.Sessions.Add(session);
				context.SaveChanges();

				// Generate downtime
				List<StringListItem> Resources = new List<StringListItem>();
				Resources.Add(new StringListItem
				{
					Id = 1,
					Item = "Herbalism kit, gold, and time."
				});
				List<StringListItem> Resolution = new List<StringListItem>();
				Resources.Add(new StringListItem
				{
					Id = 2,
					Item = "No roll. Potion made depends on gold and time invested"
				});
                

				Downtime downtime;
                downtime = new Downtime
                {
                    Id = 0,
                    Name = "Brewing a Potion of Healing",
                    Status = true,
                    Resources = Resources,
                    Resolution = Resolution,
                    Achievements = new List<Achievement>()
                };
                StringListItem[,] tab = new StringListItem[5, 3]
                {
                    { new StringListItem { Id = 20, Item = "Potion Type" }, new StringListItem { Id = 21, Item = "Downtime" }, new StringListItem { Id = 22, Item = "Gold Cost" } },
                        { new StringListItem { Id = 23, Item = "Potion of Healing" }, new StringListItem { Id = 24, Item = "One Day" }, new StringListItem { Id = 25, Item = "25 gp" } },
                        { new StringListItem { Id = 26, Item = "Potion of Greater Healing" }, new StringListItem { Id = 27, Item = "One Workweek" }, new StringListItem { Id = 28, Item = "100 gp" } },
                        { new StringListItem { Id = 29, Item = "Potion of Superior Healing" }, new StringListItem { Id = 30, Item = "Three Workweeks" }, new StringListItem { Id = 31, Item = "1,000 gp" } },
                        { new StringListItem { Id = 32, Item = "Potion of Supreme Healing" }, new StringListItem { Id = 33, Item = "Four Workweeks" }, new StringListItem { Id = 34, Item = "5,000 gp" } }
                }; 

				List<DowntimeTable> ResTable = new List<DowntimeTable>();
				List<DowntimeTableRow> tab2 = new List<DowntimeTableRow>();
				
                for(int i = 0; i<tab.GetLength(0); i++)
                {
                    DowntimeTableRow row = new DowntimeTableRow();
                    row.Row = new List<StringListItem>();
					for (int j = 0; j<tab.GetLength(1); j++)
                    {
                        row.Row.Append(tab[i, j]);
					}
                    tab2.Add(row);
				}
				ResTable.Add(new DowntimeTable
				{
					Id = 1,
					Name = "Potion Brewing Table",
					HasHead = true,
                    Table = tab2,
					DowntimeParent = downtime

				});
                downtime.Tables = ResTable;
				context.Downtime.Add(downtime);
				context.SaveChanges();
			}
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
