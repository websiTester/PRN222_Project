using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetAllCategoryService : IGetAllCategoriesService
	{
		private IGetAllCategoriesRepository _repository;
		public GetAllCategoryService(IGetAllCategoriesRepository repository)
		{
			_repository = repository;
		}
		public List<ProductCategory> GetAllCategories()
		{
			return _repository.GetAllCategories();
		}
	}
}
