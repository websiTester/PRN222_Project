﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PRN222_Project.ViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[Remote(action: "IsUsernameInUse", controller: "Account")]
		public string Username { get; set; }

		[Required]
		[EmailAddress]
		[Remote(action: "IsEmailInUse", controller: "Account")]
		public string Email { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[Compare("Password",ErrorMessage = "Passwords and Confirm Password do not match")]
		public string ConfirmPassword { get; set; }
	}
}
