using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetAllBrandsRepository : IGetAllBrandsRepository
	{
		private IDBContext _context;
		public GetAllBrandsRepository(IDBContext context)
		{
			_context = context;
		}
		public List<Brand> GetAllBrands()
		{
			return _context.GetContext().Brands.ToList();
		}
	}
}
