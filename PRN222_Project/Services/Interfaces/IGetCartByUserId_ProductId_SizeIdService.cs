using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetCartByUserId_ProductId_SizeIdService
	{
		Cart? GetCartByUserId_ProductId_SizeId(string userId, int productId, int sizeId);

	}
}
