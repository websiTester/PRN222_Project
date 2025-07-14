using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetAllCartByUserIdRepository
	{
		List<Cart> GetAllCartByUserId(string userId);
	}
}
