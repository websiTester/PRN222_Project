using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetAllCategoriesRepository : IGetAllCategoriesRepository
	{
		private IDBContext _context;
		public GetAllCategoriesRepository(IDBContext context)
		{
			_context = context;
		}
		public List<ProductCategory> GetAllCategories()
		{
			return _context.GetContext().ProductCategories.ToList();
		}
	}
}
