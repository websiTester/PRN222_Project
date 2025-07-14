using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetListOrderByUserIdService
	{
		List<Order> GetListOrderByUserId(string userId);
	}
}
