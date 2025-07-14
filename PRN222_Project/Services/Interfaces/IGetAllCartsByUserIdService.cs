using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetAllCartsByUserIdService
	{
		List<Cart> GetAllCartsByUserId(string userId);
	}
}
