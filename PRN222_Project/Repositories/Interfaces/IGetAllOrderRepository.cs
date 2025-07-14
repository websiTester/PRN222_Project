using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetAllOrderRepository
	{
		List<Order> GetAllOrders();
		List<Order> GetAssignedOrder();
		List<Order> GetUnProcessedOrder();
	}
}
