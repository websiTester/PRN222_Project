using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class DeleteAllCartByUserIdService : IDeleteAllCartByUserIdService
	{
		private IDeleteAllCartByUserIdRepository _repository;
		public DeleteAllCartByUserIdService(IDeleteAllCartByUserIdRepository repository)
		{
			_repository = repository;
		}
		public void DeleteAllCartByUserId(string userId)
		{
			_repository.DeleteAllCartByUserId(userId);
		}
	}
}
