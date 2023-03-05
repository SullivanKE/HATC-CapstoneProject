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
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }

/*            if (await userManager.FindByNameAsync(username) == null)
            {
                Player user = new Player { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }*/
        }
    }
}
