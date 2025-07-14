using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetListOrderByUserIdService : IGetListOrderByUserIdService
	{
		private IGetListOrderByUserIdRepository _repository;
		public GetListOrderByUserIdService(IGetListOrderByUserIdRepository repository)
		{
			_repository = repository;
		}
		public List<Order> GetListOrderByUserId(string userId)
		{
			return _repository.GetListOrderByUserId(userId);
		}
	}
}
