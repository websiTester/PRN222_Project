using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetAllBrandService : IGetAllBrandService
	{
		private IGetAllBrandsRepository _repository;
		public GetAllBrandService(IGetAllBrandsRepository repository)
		{
			_repository = repository;
		}
		public List<Brand> GetAllBrands()
		{
			return _repository.GetAllBrands();
		}
	}
}
