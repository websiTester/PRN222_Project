using PRN222_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN222_Project.ViewModels
{
	public class ChangePasswordViewModel
	{
		public User? User { get; set; }

		public string? CurrentPassword { get; set; }
		[Required]
		public string NewPassword { get; set; }
		[Required]
		[Compare("NewPassword", ErrorMessage = "Passwords and Confirm Password do not match")]
		public string ConfirmPassword { get; set; }


	}
}
