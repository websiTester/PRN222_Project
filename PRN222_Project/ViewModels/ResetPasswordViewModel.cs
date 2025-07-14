using System.ComponentModel.DataAnnotations;

namespace PRN222_Project.ViewModels
{
	public class ResetPasswordViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "Passwords and Confirm Password do not match")]
		public string ConfirmPassword { get; set; }
		public string Token { get; set; }
	}
}
