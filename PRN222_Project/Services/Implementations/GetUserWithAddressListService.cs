using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetUserWithAddressListService : IGetUserWithAddressListService
	{
		private IGetUserWithAddressListRepository _repository;
		public GetUserWithAddressListService(IGetUserWithAddressListRepository repository)
		{
			_repository = repository;
		}
		public User GetUserWithAddressList(string userId)
		{
			return _repository.GetUserWithAddressList(userId);
		}
	}
}
