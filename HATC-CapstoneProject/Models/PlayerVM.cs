using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace HATC_CapstoneProject.Models
{
	public class PlayerVM
	{
		public IEnumerable<Player> Players { get; set; } = null!;
		public IEnumerable<IdentityRole> Roles { get; set; } = null!;
	}
}
