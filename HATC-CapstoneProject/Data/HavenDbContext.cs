using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HATC_CapstoneProject.Models;
using Microsoft.EntityFrameworkCore;

namespace HATC_CapstoneProject.Data
{
    public class HavenDbContext : IdentityDbContext
    {
        public HavenDbContext(
            DbContextOptions<HavenDbContext> options) : base(options) { }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Faction> Factions { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<ShopItem> Shop { get; set; }
        public DbSet<Downtime> Downtime { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
