using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetCartByUserId_ProductId_SizeIdRepository
	{
		Cart? GetCartByUserId_ProductId_SizeId(string userId, int productId, int sizeId);
	}
}
