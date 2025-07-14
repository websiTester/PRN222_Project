using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class DeleteAddressByIdService : IDeleteAddressByIdService
	{
		private IDeleteAddressByIdRepository _repository;
		public DeleteAddressByIdService(IDeleteAddressByIdRepository repository)
		{
			_repository = repository;
		}
		public void DeleteAddressById(int id)
		{
			_repository.DeleteAddressById(id);
		}
	}
}
