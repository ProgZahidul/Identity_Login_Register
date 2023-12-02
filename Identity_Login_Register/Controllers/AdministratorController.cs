using Identity_Login_Register.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Identity_Login_Register.Controllers
{
	[Authorize]
	public class AdministratorController : Controller
	{
		private readonly RoleManager<IdentityRole> roleManager;
		private readonly UserManager<IdentityUser> userManager;

		public AdministratorController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
		{
			this.roleManager = roleManager;
			this.userManager = userManager;
		}


		[HttpGet]
		public IActionResult Index()
		{


			List<RoleModel> roles = roleManager.Roles.Select(r => new RoleModel() { Id = r.Id, RoleName = r.Name }).ToList();

			//foreach (var role in roleManager.Roles)
			//{
			//	RoleModel uRole = new RoleModel()
			//	{
			//		Id = role.Id,
			//		RoleName = role.Name
			//	};

			//	roles.Add(uRole);
			//}

			return View(roles);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult>Create(RoleModel model)
		{
			if (ModelState.IsValid)
			{
				IdentityRole identityRole = new IdentityRole();
				identityRole.Name = model.RoleName;
				var result=await roleManager.CreateAsync(identityRole);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");

				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
		}
		[HttpGet]
		public async Task <IActionResult>Edit(String?id)
		{
			if(id is null)
			{
				return BadRequest();
			}
			var role=await roleManager.FindByIdAsync(id);
			if (role is null)
			{
				return NotFound("your assign role does not exist : " +id);

			}
			RoleModel roleModel = new RoleModel() { Id=role.Id, RoleName=role.Name};
			return View(roleModel);
		}
		[HttpPost]
		public async Task<IActionResult> Edit (RoleModel roleModel)
		{
			if (ModelState.IsValid)
			{
				IdentityRole identityRole=new IdentityRole();
				identityRole.Id = roleModel.Id;
				identityRole.Name = roleModel.RoleName;
				var result=await roleManager.UpdateAsync(identityRole);
				if (result.Succeeded)
				{
					return RedirectToAction("Index");

				}
                foreach (var Error in result.Errors)
                {
					ModelState.AddModelError("", Error.Description);
                }
            }
			return View(roleModel);
		}
	}
}
