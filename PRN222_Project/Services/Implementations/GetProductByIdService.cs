using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetProductByIdService : IGetProductByIdService
	{
		private IGetProductByIdRepository _repository;
		public GetProductByIdService(IGetProductByIdRepository repository)
		{
			_repository = repository;
		}
		public Product GetProductById(int id)
		{
			return _repository.GetProductById(id);
		}
	}
}
