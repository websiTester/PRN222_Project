using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetAddressByIdService : IGetAddressByIdService
	{
		private IGetAddressByIdRepository _repository;
		public GetAddressByIdService(IGetAddressByIdRepository repository)
		{
			_repository = repository;
		}
		public CustomerAddress GetAddressById(int id)
		{
			return _repository.GetAddressById(id);
		}
	}
}
