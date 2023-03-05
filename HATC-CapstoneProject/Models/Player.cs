using Microsoft.AspNetCore.Identity;

namespace HATC_CapstoneProject.Models
{
    public class Player : IdentityUser
    {
        public string? PreferedName { get; set; }
        public string? Pronouns { get; set; }
        public IEnumerable<Trigger>? Triggers { get; set; }
        public string TimeZone { get; set; } = TimeZoneInfo.Utc.Id;
    }
}
