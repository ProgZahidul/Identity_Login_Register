using Identity_Login_Register.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity_Login_Register.Extensions
{
	public static class Extensions
	{
		public static void ConfigureServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddDbContext<EmployeeAppDb>(option => { option.UseSqlServer(builder.Configuration.GetConnectionString("Mydbconnetion"));
			});
			builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<EmployeeAppDb>();
		}
	}
}
