using Microsoft.AspNetCore.Identity;

namespace HATC_CapstoneProject.Models
{
    public class AppUser : IdentityUser
    {
        public string? PreferedName { get; set; }
        public string? Pronouns { get; set; }
        public Dictionary<string, string>? Triggers { get; set; }
    }
}
