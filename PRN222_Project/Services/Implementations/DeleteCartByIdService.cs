using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class DeleteCartByIdService : IDeleteCartByIdService
	{
		private IDeleteCartByIdRepository _repository;
		public DeleteCartByIdService(IDeleteCartByIdRepository repository)
		{
			_repository = repository;
		}
		public void DeleteCartById(int id)
		{
			_repository.DeleteCartById(id);
		}
	}
}
