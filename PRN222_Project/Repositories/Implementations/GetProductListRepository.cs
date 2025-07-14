using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetProductListRepository : IGetProductListRepository
	{
		private IDBContext _context;
		public GetProductListRepository(IDBContext context)
		{
			_context = context;
		}
		public List<Product> GetProductList()
		{
			return _context.GetContext().Products.Where(p => p.IsActive == true).ToList();
		}
	}
}
