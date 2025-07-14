using Azure.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PRN222_Project.Models;
using PRN222_Project.Models.VnPay;
using PRN222_Project.RequestHandlers.CartHandler;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.Services.VnPay;

namespace PRN222_Project.Controllers
{
	public class VnPayController : Controller
	{
		private IVnPayService _vnPayService;
		private IAddNewOrderService _addNewOrderService;
		private IGetVoucherByIdService _getVoucherByIdService;
		private IUpdateVoucherService _updateVoucherService;
		private IAddNewOrderDetailService _addNewOrderDetailService;
		private IGetAllCartsByUserIdService _getAllCartsByUserIdService;
		private IDeleteAllCartByUserIdService _deleteAllCartByUserIdService;
		private UserManager<User> _userManager;

		public VnPayController(
			IVnPayService vnPayService,
			IAddNewOrderService addNewOrderService,
			IGetVoucherByIdService getVoucherByIdService,
			IUpdateVoucherService updateVoucherService,
			IAddNewOrderDetailService addNewOrderDetailService,
			IGetAllCartsByUserIdService getAllCartsByUserIdService,
			IDeleteAllCartByUserIdService deleteAllCartByUserIdService,
			UserManager<User> userManager
			)
		{
			_vnPayService = vnPayService;
			_addNewOrderService = addNewOrderService;
			_getVoucherByIdService = getVoucherByIdService;
			_updateVoucherService = updateVoucherService;
			_addNewOrderDetailService = addNewOrderDetailService;
			_getAllCartsByUserIdService = getAllCartsByUserIdService;
			_deleteAllCartByUserIdService = deleteAllCartByUserIdService;
			_userManager = userManager;
		}
		//public IActionResult CreatePaymentUrlVnpay(PaymentInformationModel model)
		//{
		//	var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

		//	return Redirect(url);
		//}

		public IActionResult CreatePaymentUrlVnpay(string name, double amount, string orderType, string orderDescription)
		{
			PaymentInformationModel model = new PaymentInformationModel()
			{
				Name = name,
				Amount = amount,
				OrderType = orderType,
				OrderDescription = orderDescription
			};
			var url = _vnPayService.CreatePaymentUrl(model, HttpContext);

			return Redirect(url);
		}
		[HttpGet]
		public async Task<IActionResult> PaymentCallbackVnpay()
		{
			User user = await _userManager.GetUserAsync(User);
			var response = _vnPayService.PaymentExecute(Request.Query);
			int totalPrice = HttpContext.Session.GetInt32("totalPrice") ?? -1;
			int? voucherId = HttpContext.Session.GetInt32("voucherId");
			int totalQuantity = HttpContext.Session.GetInt32("totalQuantity") ?? -1;
			int paymentMethodId = HttpContext.Session.GetInt32("paymentMethodId") ?? -1;
			int addressId = HttpContext.Session.GetInt32("addressId") ?? -1;
			string transactionId = response.TransactionId;

			Order newOrder = await CheckoutHandler.AddNewOrder(
				user, 
				totalPrice, 
				voucherId, 
				totalQuantity,
				paymentMethodId, 
				addressId, 
				transactionId, 
				_addNewOrderService, 
				_getVoucherByIdService,
				_updateVoucherService);

			await CheckoutHandler.AddOrderDetail(
				newOrder, 
				user, 
				_addNewOrderDetailService, 
				_getAllCartsByUserIdService);

			CheckoutHandler.DeleteAllCart(
				_deleteAllCartByUserIdService,
				user);

			HttpContext.Session.SetInt32("TotalCart", 0);

			return RedirectToAction("CheckoutSuccess", "Cart");
		}

//	
//  "orderDescription": "truong Payment through VNPAY 612750",
//  "transactionId": "15070564",
//  "orderId": "638879590411289086",
//  "paymentMethod": "VnPay",
//  "paymentId": "15070564",
//  "success": true,
//  "token": "05b25b3916bf999f17f0f7ce7e9a14e7d2ecd47fc6643ec35a9c21572a7d5efedc961590109434db41adef9497811db4f77bf451c2d2440e7b28c52272010b5d",
//  "vnPayResponseCode": "00"
//

}
}
