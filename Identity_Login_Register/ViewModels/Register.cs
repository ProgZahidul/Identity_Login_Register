using System.ComponentModel.DataAnnotations;

namespace Identity_Login_Register.ViewModels
{
	public sealed class Register:Login
	{
		public Register() 
		{
			base.RememberMe = true;
		
		}
		[Compare("Password")]
		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		public string ConfirmPassword { get; set; } = default!;
	}
}
