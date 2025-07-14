using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetCartByUserId_ProductId_SizeIdRepository : IGetCartByUserId_ProductId_SizeIdRepository
	{
		private IDBContext _context;
		public GetCartByUserId_ProductId_SizeIdRepository(IDBContext context)
		{
			_context = context;
		}
		public Cart? GetCartByUserId_ProductId_SizeId(string userId, int productId, int sizeId)
		{
			return _context.GetContext().Carts
				.Include(c => c.Product)
				.ThenInclude(p => p.ProductSizes)
				.FirstOrDefault(c => c.UserId == userId && 
									 c.ProductId == productId && 
									 c.SizeId == sizeId);
		}
	}
}
