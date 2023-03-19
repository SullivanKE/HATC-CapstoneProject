using HATC_CapstoneProject.Models;
using HATC_CapstoneProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HATC_CapstoneProject.Controllers
{
    public class PlayerController : Controller
    {
		//[Authorize(Roles = "DM")]
		private UserManager<Player> userManager;
		private RoleManager<IdentityRole> roleManager;
		public PlayerController(UserManager<Player> userMngr, RoleManager<IdentityRole> roleMngr, HavenDbContext context)
		{
			userManager = userMngr;
			roleManager = roleMngr;
		}

		public async Task<IActionResult> Index()
		{
			List<Player> users = new List<Player>();

			//Player user = userManager.FindByNameAsync("admin").Result;
			foreach (Player user in userManager.Users.ToList())
			{
				user.RoleNames = await userManager.GetRolesAsync(user);

				users.Add(user);
			}

			PlayerVM model = new PlayerVM
			{
				Players = users,
				Roles = roleManager.Roles
			};

			return View(model);
		} // the other action methods } 

		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			Player user = await userManager.FindByIdAsync(id);

			if (user != null)
			{
				IdentityResult result = await userManager.DeleteAsync(user);

				if (!result.Succeeded)
				{ // if failed
					string errorMessage = "";
					foreach (IdentityError error in result.Errors)
					{
						errorMessage += error.Description + " | ";
					}
					TempData["message"] = errorMessage;
				}
			}
			return RedirectToAction("Index");
		}
		// the Add() methods work like the Register() methods from 16-11 and 16-12 [HttpPost]
		public async Task<IActionResult> AddToAdmin(string id)
		{
			IdentityRole adminRole = await roleManager.FindByNameAsync("DM");

			if (adminRole == null)
			{
				TempData["message"] = "DM role does not exist. " + "Click 'Create DM Role' button to create it.";
			}
			else
			{
				Player user = await userManager.FindByIdAsync(id); await userManager.AddToRoleAsync(user, adminRole.Name);
			}
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> RemoveFromAdmin(string id)
		{
			Player user = await userManager.FindByIdAsync(id);
			await userManager.RemoveFromRoleAsync(user, "DM");
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> DeleteRole(string id)
		{
			IdentityRole role = await roleManager.FindByIdAsync(id);
			await roleManager.DeleteAsync(role);
			return RedirectToAction("Index");
		}
		[HttpPost]
		public async Task<IActionResult> CreateAdminRole()
		{
			await roleManager.CreateAsync(new IdentityRole("DM"));
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(RegisterVM model, string pass)
		{

			//if (ModelState.IsValid)
			{
				var user = new Player { UserName = model.Username };
				var result = await userManager.CreateAsync(user, pass);
				if (result.Succeeded)
				{
					IdentityRole playerRole = await roleManager.FindByNameAsync("Player");
					if (playerRole == null)
					{
						TempData["message"] = "Player role does not exist. " + "Click 'Create Player Role' button to create it.";
					}
					else
					{
						await userManager.AddToRoleAsync(user, playerRole.Name);
					}

					return RedirectToAction("Index");
				}
				else
				{
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}
			}
			return View(model);
		}

		public async Task<IActionResult> ResetPassword(string id)
		{
			Player user = await userManager.FindByIdAsync(id);

			if (user == null)
			{
				TempData["message"] = "User does not exist.";
			}
			else
			{
				await userManager.SetLockoutEnabledAsync(user, false);
				await userManager.ResetAccessFailedCountAsync(user);
				await userManager.RemovePasswordAsync(user);
				user.PasswordReset = true;
			}
			return RedirectToAction("Index");
		}
	}
}
