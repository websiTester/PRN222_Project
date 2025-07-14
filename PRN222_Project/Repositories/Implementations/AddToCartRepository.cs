using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class AddToCartRepository : IAddToCartRepository
	{
		private IDBContext _context;
		public AddToCartRepository(IDBContext context)
		{
			_context = context;
		}
		public void AddToCart(Cart cart)
		{
			_context.GetContext().Carts.Add(cart);
			_context.GetContext().SaveChanges();
		}
	}
}
