using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class DeleteCartByIdRepository : IDeleteCartByIdRepository
	{
		private IDBContext _context;
		public DeleteCartByIdRepository(IDBContext context)
		{
			_context = context;
		}
		public void DeleteCartById(int id)
		{
			Cart cart = new Cart() { CartId = id };
			_context.GetContext().Carts.Remove(cart);
			_context.GetContext().SaveChanges();
		}
	}
}
