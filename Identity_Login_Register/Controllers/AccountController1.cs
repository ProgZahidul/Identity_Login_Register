using Identity_Login_Register.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_Login_Register.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<IdentityUser> signManager;
		private readonly UserManager<IdentityUser> userManager;

		public AccountController(SignInManager<IdentityUser> sign, UserManager<IdentityUser> userManager)
		{
			this.signManager = sign;
			this.userManager = userManager;
		}


		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Register(Register register)
		{

			if (ModelState.IsValid)
			{
				IdentityUser identity = new IdentityUser() { UserName = register.Email, Email = register.Email };

				var result = await userManager.CreateAsync(identity, register.Password);


				if (result.Succeeded)
				{

					await signManager.PasswordSignInAsync(identity, register.Password, register.RememberMe, false);


					return RedirectToAction("Index", "Home");

				}



				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}


			}


			return View(register);
		}
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Login(Login login, string? ReturnUrl)
		{

			if (ModelState.IsValid)
			{

				IdentityUser identity = new IdentityUser() { UserName = login.Email };


				var result = await signManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false);


				if (result.Succeeded)
				{

					if (Url.IsLocalUrl(ReturnUrl))
					{
						return RedirectPermanent(ReturnUrl);
					}

					return RedirectToAction("Index", "Home");
				}
				else
				{
					ModelState.AddModelError("", "Invalid credential, try again...");
				}

			}
			


			return View(login);
		}
        [HttpPost]
		public async Task<IActionResult>logout()
		{
			await signManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
    }
}
