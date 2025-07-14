using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetProductListService : IGetProductListService
	{
		private IGetProductListRepository _repository;
		public GetProductListService(IGetProductListRepository repository)
		{
			_repository = repository;
		}
		public List<Product> GetProductList()
		{
			return _repository.GetProductList();
		}
	}
}
