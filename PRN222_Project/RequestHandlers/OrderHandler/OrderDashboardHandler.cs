using Microsoft.AspNetCore.Identity;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;
using System.Reflection.Emit;

namespace PRN222_Project.RequestHandlers.OrderHandler
{
	public class OrderDashboardHandler
	{
		public static DashboardViewModel GetDashboardStatistic(UserManager<User> _userManager,
			IGetProductListService _getProductListService, IGetAllOrderService _getAllOrderService,
			DateTime? fromDate, DateTime? toDate)
		{
			

			int totalUsers = _userManager.Users.Count();
			int totalProducts = _getProductListService.GetProductList().Count();
			int totalOrders = _getAllOrderService.GetAllOrders().Count();
			int totalRevenue = _getAllOrderService.GetAllOrders()
								.Where(x => x.OrderStatusId == 4 && x.PaymentStatusId == 2)
								.Sum(x => x.TotalPrice) ?? 0;

			DashboardViewModel model = new DashboardViewModel()
			{
				TotalUsers = totalUsers,
				TotalProducts = totalProducts,
				TotalOrders = totalOrders,
				TotalRevenue = totalRevenue
			};
			model.OrderChartList = GetOrderChart(_getAllOrderService, fromDate,toDate);
			return model;
		}


		public static List<OrderChart> GetOrderChart(IGetAllOrderService _getAllOrderService, 
			DateTime? fromDate, DateTime? toDate)
		{
			fromDate = fromDate ?? DateTime.MinValue.Date;
			toDate = toDate ?? DateTime.MaxValue.Date;
			List<OrderChart> orderCharts = new List<OrderChart>();
			orderCharts = _getAllOrderService.GetAllOrders().Where(o => o.OrderedDate >= fromDate && o.OrderedDate <= toDate)
				.GroupBy(o => o.OrderStatusId).Select(
				g => new OrderChart
				{
					Label = g.First().OrderStatus.OrderStatusName,
					Value = g.Count()
				}
				).ToList();
			return orderCharts;
		}
	}
}
