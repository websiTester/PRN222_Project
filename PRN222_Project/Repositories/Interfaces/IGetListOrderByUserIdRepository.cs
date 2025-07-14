using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetListOrderByUserIdRepository
	{
		List<Order> GetListOrderByUserId(string userId);
	}
}
