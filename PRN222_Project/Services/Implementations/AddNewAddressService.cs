using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class AddNewAddressService : IAddNewAddressService
	{
		private IAddNewAddressRepository _repository;
		public AddNewAddressService(IAddNewAddressRepository repository)
		{
			_repository = repository;
		}
		public void AddNewAddress(CustomerAddress address)
		{
			_repository.AddNewAddress(address);
		}
	}
}
