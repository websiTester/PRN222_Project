using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetProductByIdRepository : IGetProductByIdRepository
	{
		private IDBContext _context;
		public GetProductByIdRepository(IDBContext context)
		{
			_context = context;
		}
		public Product GetProductById(int id)
		{
			return _context.GetContext().Products.Include(p => p.Feedbacks)
				.Include(p => p.ProductImages)
				.Include(p => p.ProductSizes).ThenInclude(ps => ps.Size)
				.Where(p => p.ProductId == id).FirstOrDefault();
		}
	}
}
