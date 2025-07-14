using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class UpdateUserProfileService : IUpdateUserProfileService
	{
		private IUpdateUserProfileRepository _repository;
		public UpdateUserProfileService(IUpdateUserProfileRepository repository)
		{
			_repository = repository;
		}
		public void UpdateUserProfile(User user)
		{
			_repository.UpdateUserProfile(user);
		}
	}
}
