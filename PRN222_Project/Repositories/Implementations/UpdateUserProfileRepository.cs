using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class UpdateUserProfileRepository : IUpdateUserProfileRepository
	{
		private IDBContext _context;
		public UpdateUserProfileRepository(IDBContext context)
		{
			_context = context;
		}
		public void UpdateUserProfile(User user)
		{
			_context.GetContext().Users.Update(user);
			_context.GetContext().SaveChanges();
		}
	}
}
