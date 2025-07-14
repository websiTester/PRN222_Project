using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetCartByUserId_ProductId_SizeIdService : IGetCartByUserId_ProductId_SizeIdService
	{
		private IGetCartByUserId_ProductId_SizeIdRepository _repository;
		public GetCartByUserId_ProductId_SizeIdService(IGetCartByUserId_ProductId_SizeIdRepository repository)
		{
			_repository = repository;
		}
		public Cart? GetCartByUserId_ProductId_SizeId(string userId, int productId, int sizeId)
		{
			return _repository.GetCartByUserId_ProductId_SizeId(userId, productId, sizeId);
		}
	}
}
