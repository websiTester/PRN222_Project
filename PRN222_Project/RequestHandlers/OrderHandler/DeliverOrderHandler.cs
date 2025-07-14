using PRN222_Project.Models;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.OrderHandler
{
	public class DeliverOrderHandler
	{
		public static void DeliverOrder(Order order, int orderStatusId, 
			IUpdateProductSizeService _updateProductSizeService, 
			IUpdateOrderService _updateOrderService)
		{
			foreach (OrderDetail orderDetail in order.OrderDetails)
			{
				ProductSize productSize = orderDetail.Product.ProductSizes
					.FirstOrDefault(x => x.SizeId == orderDetail.SizeId);
				productSize.Quantity -= orderDetail.Quantity;
				_updateProductSizeService.UpdateProductSize(productSize);
			}
			order.OrderStatusId = orderStatusId;
			_updateOrderService.UpdateOrder(order);
		}
	}
}
