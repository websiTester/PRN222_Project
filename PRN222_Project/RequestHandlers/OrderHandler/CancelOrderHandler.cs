using PRN222_Project.Models;
using PRN222_Project.Services.Implementations;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.OrderHandler
{
	public class CancelOrderHandler
	{
		public static void CancelOrder(Order order, int orderStatusId,
			IUpdateProductSizeService _updateProductSizeService, 
			IUpdateOrderService _updateOrderService,
			IGetVoucherByIdService _getVoucherByIdService,
			IUpdateVoucherService _updateVoucherService
			)
		{
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
			if(order.VoucherId != null)
			{
				Voucher voucher = _getVoucherByIdService.GetVoucherById((int)order.VoucherId);
				voucher.Quantity += 1;
				_updateVoucherService.UpdateVoucher(voucher);
			}

			order.OrderStatusId = orderStatusId;
			_updateOrderService.UpdateOrder(order);
		}
	}
}
