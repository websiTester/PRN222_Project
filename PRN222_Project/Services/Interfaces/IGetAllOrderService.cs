using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetAllOrderService
	{
		List<Order> GetAllOrders();
		List<Order> GetAssignedOrder();
		List<Order> GetUnProcessedOrder();
		List<Order> GetPendingRefundOrders();
	}
}
