using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetDefaultAddressByUserIdService : IGetDefaultAddressByUserIdService
	{
		private IGetDefaultAddressByUserIdRepository _repository;
		public GetDefaultAddressByUserIdService(IGetDefaultAddressByUserIdRepository repository)
		{
			_repository = repository;
		}
		public CustomerAddress GetDefaultAddressByUserId(string userId)
		{
			return _repository.GetDefaultAddressByUserId(userId);
		}
	}
}
