using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class DeleteAllCartByUserIdRepository : IDeleteAllCartByUserIdRepository
	{
		private IDBContext _context;
		public DeleteAllCartByUserIdRepository(IDBContext context)
		{
			_context = context;
		}
		public void DeleteAllCartByUserId(string userId)
		{
			_context.GetContext().Carts.RemoveRange(
				_context.GetContext().Carts
				.Where(c => c.UserId.ToLower() == userId.ToLower()));
			_context.GetContext().SaveChanges();
		}
	}
}
