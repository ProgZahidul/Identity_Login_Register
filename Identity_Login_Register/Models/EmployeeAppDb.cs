using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity_Login_Register.Models
{
	public class EmployeeAppDb:IdentityDbContext
	{
        public EmployeeAppDb(DbContextOptions<EmployeeAppDb> options):base(options) { }
       
    }
}
