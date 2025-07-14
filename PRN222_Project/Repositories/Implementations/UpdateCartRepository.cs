using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class UpdateCartRepository : IUpdateCartRepository
	{
		private IDBContext _context;
		public UpdateCartRepository(IDBContext context)
		{
			_context = context;
		}
		public void UpdateCart(Cart cart)
		{
			_context.GetContext().Carts.Update(cart);	
			_context.GetContext().SaveChanges();
		}
	}
}
