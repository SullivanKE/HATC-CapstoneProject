using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HATC_CapstoneProject.Models
{
    public class Player : IdentityUser
    {
        public string? PreferedName { get; set; }
        public string DiscordName { get; set; } = "";
        public string? Pronouns { get; set; }
        public IEnumerable<Trigger>? Triggers { get; set; }
        public string TimeZone { get; set; } = TimeZoneInfo.Utc.Id;
        public bool PasswordReset { get; set; } = true;

		[NotMapped]
		public IList<string> RoleNames { get; set; } = null!;
    }
}
