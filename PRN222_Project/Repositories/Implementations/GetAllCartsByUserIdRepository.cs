using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetAllCartsByUserIdRepository : IGetAllCartByUserIdRepository
	{
		private IDBContext _context;
		public GetAllCartsByUserIdRepository(IDBContext context)
		{
			_context = context;
		}
		public List<Cart> GetAllCartByUserId(string userId)
		{
			return _context.GetContext().Carts
				.Include(c => c.Product)
				.ThenInclude(p => p.ProductSizes)
				.ThenInclude(ps => ps.Size)
				.Where(c => c.UserId.ToLower() == userId.ToLower()).ToList();
		}
	}
}
