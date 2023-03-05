using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;

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
            }
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
