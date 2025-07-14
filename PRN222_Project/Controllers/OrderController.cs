using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PagedList;
using PRN222_Project.Models;
using PRN222_Project.RequestHandlers.CartHandler;
using PRN222_Project.RequestHandlers.OrderHandler;
using PRN222_Project.Services.Implementations;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;

namespace PRN222_Project.Controllers
{
	[Authorize(Roles = "Sale Manager")]
	public class OrderController : Controller
	{
		private IGetAllOrderService _getAllOrderService;
		private IGetOrderByIdService _getOrderByIdService;
		private IUpdateOrderService _updateOrderService;
		private UserManager<User> _userManager;
		private IUpdateProductSizeService _updateProductSizeService;
		private IGetVoucherByIdService _getVoucherByIdService;
		private IUpdateVoucherService _updateVoucherService;
		private IGetProductListService _getProductListService;
		private IUpdateUserProfileService _updateUserProfileService;

		public OrderController(
			UserManager<User> userManager,
			IGetAllOrderService getAllOrderService,
			IGetOrderByIdService getOrderByIdService,
			IUpdateOrderService updateOrderService,
			IUpdateProductSizeService updateProductSizeService,
			IUpdateVoucherService updateVoucherService,
			IGetVoucherByIdService getVoucherByIdService,
			IGetProductListService getProductListService,
			IUpdateUserProfileService updateUserProfileService
		)
		{ 
			_userManager = userManager;
			_getAllOrderService = getAllOrderService;
			_getOrderByIdService = getOrderByIdService;
			_updateOrderService = updateOrderService;
			_updateProductSizeService = updateProductSizeService;
			_updateVoucherService = updateVoucherService;
			_getVoucherByIdService = getVoucherByIdService;
			_getProductListService = getProductListService;
			_updateUserProfileService = updateUserProfileService;
		}
		
		public IActionResult ListAssignedOrderSaleManager(ListOrderSaleManagerViewModel model, int? page)
		{
			List<Order> orders = FilterOrderHandler.FilterOrders(model.OrderType,model.FromDate, model.ToDate, _getAllOrderService);
				ViewBag.OrderTitle = "All Orders";
			ListOrderSaleManagerViewModel model2 = new ListOrderSaleManagerViewModel()
			{
				OrderList = orders,
				OrderPageList = orders.ToPagedList(page ?? 1, 5),
				OrderType = model.OrderType,
				FromDate = model.FromDate,
				ToDate = model.ToDate,
				Index = ((page ?? 1) - 1) * 5 + 1
			};
			return View(model2);
		}

		public IActionResult AssignOrder(int orderId, int? orderType)
		{
			User user = _userManager.Users
				.FirstOrDefault(x => x.UserName == User.Identity.Name);

			Order order = _getOrderByIdService.GetOrderById(orderId);
			order.OrderStatusId = 2;
			order.SalerId = user.Id;
			_updateOrderService.UpdateOrder(order);
			return RedirectToAction("ListAssignedOrderSaleManager", new {orderType = orderType});
		}

		public IActionResult OrderDetailManagement(int orderId, string? quantityError)
		{
			Order order = _getOrderByIdService.GetOrderById(orderId);
			if(quantityError != null)
			{
				ViewBag.QuantityError = quantityError;
			}
			return View(order);
		}



		[HttpPost]
		//OrderStatusId = 5
		public IActionResult CancelOrder(int orderId, int orderStatusId)
		{
			Order order = _getOrderByIdService.GetOrderById(orderId);
			CancelOrderHandler.CancelOrder(order, orderStatusId, 
				_updateProductSizeService, _updateOrderService,
			 _getVoucherByIdService, _updateVoucherService);
			
			return RedirectToAction("OrderDetailManagement", new { orderId = orderId });
		}


		[HttpPost]
		//OrderStatusId = 3
		public IActionResult DeliverOrder(int orderId, int orderStatusId)
		{
			Order order = _getOrderByIdService.GetOrderById(orderId);

			string error = CheckProductQuantityHandler.IsProductAvailable(order.OrderDetails.ToList());
			if(error.Length > 0)
			{
				return RedirectToAction("OrderDetailManagement", new { orderId = orderId, quantityError = error });
			}
			else
			{
				DeliverOrderHandler.DeliverOrder(order, orderStatusId, 
					_updateProductSizeService, _updateOrderService);
			}
				

			return RedirectToAction("OrderDetailManagement", new { orderId = orderId });
		}
		[HttpPost]
		//OrderStatusId = 4
		public IActionResult ReceiveOrderSuccess(int orderId, int orderStatusId)
		{
			Order order = _getOrderByIdService.GetOrderById(orderId);
			order.OrderStatusId = orderStatusId;
			order.PaymentStatusId = 2; // Da thanh toan
			_updateOrderService.UpdateOrder(order);

			return RedirectToAction("OrderDetailManagement", new { orderId = orderId });
		}

		public async Task<IActionResult> ReturnMoney(int orderId)
		{
			User user = await _userManager.GetUserAsync(User);
			Order order = _getOrderByIdService.GetOrderById(orderId);
			order.PaymentStatusId = 5;
			user.Balance += (order.TotalPrice ?? 0);
			_updateUserProfileService.UpdateUserProfile(user);
			_updateOrderService.UpdateOrder(order);
			return RedirectToAction("OrderDetailManagement", new { orderId = orderId });
		}
		public IActionResult Dashboard(DateTime? fromDate, DateTime? toDate)
		{
			DashboardViewModel model = OrderDashboardHandler
				.GetDashboardStatistic(_userManager,_getProductListService,_getAllOrderService, fromDate, toDate);
			return View(model);
		}

	}
}
