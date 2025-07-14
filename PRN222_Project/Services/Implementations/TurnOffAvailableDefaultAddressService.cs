using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class TurnOffAvailableDefaultAddressService : ITurnOffAvailableDefaultAddressService
	{
		private ITurnOffAvailableDefaultAddressRepository _repository;
		public TurnOffAvailableDefaultAddressService(ITurnOffAvailableDefaultAddressRepository repository)
		{
			_repository = repository;
		}
		public async Task TurnOffAvailableDefaultAddress(string userId)
		{
			_repository.TurnOffAvailableDefaultAddress(userId);
		}
	}
}
