using PRN222_Project.Models;
using PRN222_Project.Services.Implementations;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.DeleteOrderHandler
{
	public class DeleteOrderHandler
	{
		public static async Task CancelOrder(
			IGetOrderByIdService _getOrderByIdService,
			IUpdateVoucherService _updateVoucherService,
			IUpdateOrderService _updateOrderService,
			IUpdateProductSizeService _updateProductSizeService,
			int orderId
			)
		{
			//await _deleteOrderDetailService.DeleteOrderDetail(orderId);
			Order order = _getOrderByIdService.GetOrderById(orderId);

			if (order.OrderStatusId == 3)
			{
				foreach (OrderDetail orderDetail in order.OrderDetails)
				{
					ProductSize productSize = orderDetail.Product.ProductSizes
						.FirstOrDefault(x => x.SizeId == orderDetail.SizeId);
					productSize.Quantity += orderDetail.Quantity;
					_updateProductSizeService.UpdateProductSize(productSize);
				}
			}
			order.OrderStatusId = 5;

			if (order.VoucherId != null)
			{
				Voucher voucher = order.Voucher;
				voucher.Quantity += 1;
				_updateVoucherService.UpdateVoucher(voucher);
			}

			//User payed for the order => Return money
			if(order.PaymentStatusId == 2)
			{
				order.PaymentStatusId = 4;
			}
			_updateOrderService.UpdateOrder(order);
		}
	}
}
