using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PRN222_Project.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public bool RememberMe { get; set; }

		public string? ReturnUrl { get; set; }  // URL to go back to after success authentication
		public IList<AuthenticationScheme>? ExternalLogins { get; set; }

	}
}
