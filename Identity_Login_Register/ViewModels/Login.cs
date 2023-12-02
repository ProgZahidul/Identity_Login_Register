using System.ComponentModel.DataAnnotations;

namespace Identity_Login_Register.ViewModels
{
	public class Login
	{
		[Required]
		[StringLength(30,MinimumLength =5)]
		[EmailAddress]
		[Display(Name ="User Name")]
		public string Email { get; set; }
		[DataType(DataType.Password)]
		public string Password { get; set; }
		[Display(Name ="Remember Me?")]
		public bool RememberMe { get; set; }


	}
}
