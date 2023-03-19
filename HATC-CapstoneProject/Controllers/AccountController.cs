using HATC_CapstoneProject.Data;
using HATC_CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HATC_CapstoneProject.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<Player> userManager;
		private SignInManager<Player> signInManager;
		private IHavenRepo repo;
		public AccountController(UserManager<Player> userMngr, SignInManager<Player> signInMngr, IHavenRepo repo)
		{
			this.userManager = userMngr;
			this.signInManager = signInMngr;
			this.repo = repo;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		public IActionResult Add()
		{
			Random rng= new Random();
			char[] characters = new char[] { '!', '@', '#', '$', '%','^','&','*' };
			string pass = StringMethods.RandomStr("AAAAAA");
			pass += characters[rng.Next(8)];
			pass += StringMethods.RandomStr("AAAAAA").ToLower();
			pass += characters[rng.Next(8)];
			pass += rng.Next(100, 999).ToString();
			ViewBag.Password = pass;

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(RegisterVM model, string pass)
		{
			var user = new Player { UserName = model.Username };

			var result = await userManager.CreateAsync(user, pass);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Account");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
	}
		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM model)
		{
			// Validation
			// if (ModelState.IsValid)
			{
				var user = new Player { UserName = model.Username };
				var result = await userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction("Index", "Home");
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

		public async Task<IActionResult> LogOut()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult LogIn(string returnURL = "")
		{
			var model = new LoginVM { ReturnUrl = returnURL };
			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> LogIn(LoginVM model)
		{
			if (ModelState.IsValid)
			{
				var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
				if (result.Succeeded)
				{
					Player user = await signInManager.UserManager.FindByNameAsync(model.Username);
					if (result.IsLockedOut)
					{
						// TODO: Lock out page
					}
					else
					{
						if (user.PasswordReset)
						{
							return RedirectToAction("Passwordreset", "Account", user);
						}
						if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
						{
							return Redirect(model.ReturnUrl);
						}
						else
						{
							return RedirectToAction("Index", "Home");
						}
					}
					
				}
			}
			ModelState.AddModelError("", "Invalid username/password.");
			return View(model);
		}

		public IActionResult Passwordreset(Player user)
		{
			ViewBag.user = user.UserName;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Passwordreset(RegisterVM model)
		{
			// Validation
			// if (ModelState.IsValid)
			{
				var user = await userManager.FindByNameAsync(model.Username);
				var reset = await userManager.RemovePasswordAsync(user);
				var result = await userManager.AddPasswordAsync(user, model.Password);

				if (result.Succeeded)
				{
					
					await signInManager.SignInAsync(user, isPersistent: false);

					string emailConfirmationCode = await userManager.GenerateEmailConfirmationTokenAsync(user);
					string passwordSetCode = await userManager.GeneratePasswordResetTokenAsync(user);
					user.PasswordReset = false;
					await userManager.UpdateAsync(user);


					/*Player u = await repo.GetPlayerAsync(user.Id);
					u.PasswordReset = false;
					await repo.SavePlayerAsync(u);*/
					return RedirectToAction("Index", "Home");
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
	}
}
