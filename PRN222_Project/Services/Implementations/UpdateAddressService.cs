using PRN222_Project.Models;
using PRN222_Project.Repositories.Implementations;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class UpdateAddressService : IUpdateAddressService
	{
		private IUpdateAddressRepository _repository;
		public UpdateAddressService(IUpdateAddressRepository repository)
		{
			_repository = repository;
		}
		public void UpdateAddress(CustomerAddress address)
		{
			_repository.UpdateAddress(address);
		}
	}
}
