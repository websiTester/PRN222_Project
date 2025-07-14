using PRN222_Project.Models;
using PRN222_Project.Repositories.Implementations;
using PRN222_Project.Services.Implementations;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.CartHandler
{
	public class CheckoutHandler
	{

		//COMMON PAYMENT
		public static async Task<Order> AddNewOrder(User user, int totalPrice,
			int? voucherId,
			int totalQuantity,
			int paymentMethodId,
			int addressId,
			IAddNewOrderService _addNewOrderService,
			IGetVoucherByIdService _getVoucherByIdService,
			IUpdateVoucherService _updateVoucherService
			)
		{
			Order order = new Order()
			{
				UserId = user.Id,
				TotalPrice = totalPrice,
				VoucherId = voucherId,
				TotalAmount = totalQuantity,
				PaymentMethodId = paymentMethodId,
				CustomerAddressId = addressId,
				OrderedDate = DateTime.Now,
				ReceiveDate = DateTime.Now+ TimeSpan.FromDays(3),
				ShippingFee = 0,
				OrderStatusId = 1,  //Cho su ly
				PaymentStatusId = 1  //Cho thanh toan
			};
			//Add Order
			Order newOrder = await _addNewOrderService.AddNewOrder(order);
			if(voucherId != null)
			{
				Voucher voucher = _getVoucherByIdService.GetVoucherById(voucherId??0);
				voucher.Quantity -= 1;
				_updateVoucherService.UpdateVoucher(voucher);
			}
			return newOrder;
			
		}


		//VNPAY PAYMENT
		public static async Task<Order> AddNewOrder(User user, int totalPrice,
			int? voucherId,
			int totalQuantity,
			int paymentMethodId,
			int addressId,
			string transactionId,
			IAddNewOrderService _addNewOrderService,
			IGetVoucherByIdService _getVoucherByIdService,
			IUpdateVoucherService _updateVoucherService
			)
		{
			Order order = new Order()
			{
				UserId = user.Id,
				TotalPrice = totalPrice,
				VoucherId = voucherId,
				TotalAmount = totalQuantity,
				PaymentMethodId = paymentMethodId,
				CustomerAddressId = addressId,
				VnpTxnRef = transactionId,
				OrderedDate = DateTime.Now,
				ReceiveDate = DateTime.Now + TimeSpan.FromDays(3),
				ShippingFee = 0,
				OrderStatusId = 1,  //Cho su ly
				PaymentStatusId = 2  //Da thanh toan
			};
			//Add Order
			Order newOrder = await _addNewOrderService.AddNewOrder(order);
			if (voucherId != null)
			{
				Voucher voucher = _getVoucherByIdService.GetVoucherById(voucherId ?? 0);
				voucher.Quantity -= 1;
				_updateVoucherService.UpdateVoucher(voucher);
			}
			return newOrder;

		}

		public static async Task AddOrderDetail(Order newOrder, User user, 
			IAddNewOrderDetailService _addNewOrderDetailService, 
			IGetAllCartsByUserIdService _getAllCartsByUserIdService)
		{
			List<Cart> CartList = _getAllCartsByUserIdService.GetAllCartsByUserId(user.Id);
			List<OrderDetail> orderDetails = new List<OrderDetail>();
			foreach (Cart cart in CartList)
			{
				orderDetails.Add(new OrderDetail()
				{
					OrderId = newOrder.OrderId,
					ProductId = cart.ProductId,
					Thumbnail = cart.Product.Thumbnail,
					ProductName = cart.Product.ProductName,
					SizeId = cart.SizeId ?? -1,
					Quantity = cart.Quantity,
					UnitPrice = cart.Product.Price,
					TotalPrice = cart.Product.Price * cart.Quantity
				});

				//ProductSize productSize = cart.Product.ProductSizes
				//	.FirstOrDefault(x => x.SizeId == cart.SizeId && x.ProductId == cart.ProductId);
				//productSize.Quantity -= cart.Quantity;

			}
			await _addNewOrderDetailService.AddNewOrderDetail(orderDetails);
		}

		public static void DeleteAllCart(IDeleteAllCartByUserIdService _deleteAllCartByUserIdService, 
			User user)
		{
			_deleteAllCartByUserIdService.DeleteAllCartByUserId(user.Id);
		}
	}
}
