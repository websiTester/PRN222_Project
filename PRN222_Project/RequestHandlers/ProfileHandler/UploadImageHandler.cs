using Microsoft.AspNetCore.Identity;
using PRN222_Project.Models;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.ProfileHandler
{
	public class UploadImageHandler
	{
		public static async Task SaveImage(IFormFile file, User user, 
			IUpdateUserProfileService _updateUserProfileService)
		{
			using var ms = new MemoryStream();
			await file.CopyToAsync(ms);
			var imageBytes = ms.ToArray();
			var base64 = Convert.ToBase64String(imageBytes);
			user.ProfilePictureUrl = base64;
			_updateUserProfileService.UpdateUserProfile(user);
		}
	}
}
