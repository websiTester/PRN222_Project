using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetOrderByIdService : IGetOrderByIdService
	{
		private IGetOrderByIdRepository _repository;
		public GetOrderByIdService(IGetOrderByIdRepository repository)
		{
			_repository = repository;
		}
		public Order GetOrderById(int id)
		{
			return _repository.GetOrderById(id);
		}
	}
}
