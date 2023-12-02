using System.ComponentModel.DataAnnotations;

namespace Identity_Login_Register.ViewModels
{
	public class RoleModel
	{
		public string? Id { get; set; }
		[Required]
		[StringLength(50, MinimumLength =4)]
		public string RoleName { get; set; }
	}
}
