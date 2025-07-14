using System.ComponentModel.DataAnnotations;

namespace PRN222_Project.ViewModels
{
	public class ForgetPasswordViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
	}
}
