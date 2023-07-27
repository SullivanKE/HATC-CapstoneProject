#nullable disable

namespace HATC_CapstoneProject.Data;

public class HavenDbContext : IdentityDbContext<Player>
{
    public DbSet<Session> Sessions { get; set; }
    public DbSet<Faction> Factions { get; set; }
    public DbSet<Achievement> Achievements { get; set; }
    public DbSet<ShopItem> Shop { get; set; }
    public DbSet<Downtime> Downtime { get; set; }
    public DbSet<Character> Characters { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Rank> Ranks { get; set; }

    public HavenDbContext(DbContextOptions<HavenDbContext> options) : base(options)
    {

    }
    public HavenDbContext()
    {

    }
}
