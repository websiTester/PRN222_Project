using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetAllCartsByUserIdService : IGetAllCartsByUserIdService
	{
		private IGetAllCartByUserIdRepository _repository;
		public GetAllCartsByUserIdService(IGetAllCartByUserIdRepository repository)
		{
			_repository = repository;
		}
		public List<Cart> GetAllCartsByUserId(string userId)
		{
			return _repository.GetAllCartByUserId(userId);
		}
	}
}
