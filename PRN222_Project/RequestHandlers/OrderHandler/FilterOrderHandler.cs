using PRN222_Project.Models;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.OrderHandler
{
	public class FilterOrderHandler
	{
		public static List<Order> FilterOrders(int? orderType, DateTime? fromDate, DateTime? toDate, 
			IGetAllOrderService _getAllOrderService)
		{
			List<Order> orders = new List<Order>();
			if (orderType == 1 || orderType == null)
			{
				orders = _getAllOrderService.GetAllOrders();
			}
			else if (orderType == 2)
			{
				orders = _getAllOrderService.GetAssignedOrder();
			}
			else if (orderType == 3)
			{
				orders = _getAllOrderService.GetUnProcessedOrder();
			}
			else if(orderType == 4)
			{
				orders = _getAllOrderService.GetPendingRefundOrders();
			}
			if (fromDate != null)
			{
				orders = orders.Where(o => o.OrderedDate >= fromDate).ToList();
			}
			if (toDate != null)
			{
				orders = orders.Where(o => o.OrderedDate <= toDate).ToList();
			}
			return orders;
		}
	}
}
