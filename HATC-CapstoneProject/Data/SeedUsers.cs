using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;

namespace HATC_CapstoneProject.Data
{
    public class SeedUsers
    {
        public static async Task CreateAdminUserAsync(IServiceProvider provider)
        {
            var roleManager =
            provider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager =
            provider.GetRequiredService<UserManager<Player>>();

            string username = "admin";
            string password = "Password1!"; // We will fix this
            string roleName = "DM";

			string username1 = "player";
			string password1 = "Password1!"; // We will fix this
			string roleName1 = "Player";

			// if role doesn't exist, create it
			if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
				await roleManager.CreateAsync(new IdentityRole(roleName1));
			}

            if (await userManager.FindByNameAsync(username) == null)
            {
                Player user = new Player { UserName = username };
                var result = await userManager.CreateAsync(user, password);

				Player user1 = new Player { UserName = username1 };
				var result1 = await userManager.CreateAsync(user1, password1);
				if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
				if (result1.Succeeded)
				{
					await userManager.AddToRoleAsync(user1, roleName1);
				}
			}
        }
    }
}
