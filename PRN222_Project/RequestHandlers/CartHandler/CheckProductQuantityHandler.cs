using PRN222_Project.Models;

namespace PRN222_Project.RequestHandlers.CartHandler
{
	public class CheckProductQuantityHandler
	{
		public static string IsProductAvailable(List<Cart> cartList)
		{
			string errorMessage = "";	
			foreach (Cart cart in cartList)
			{
				ProductSize productSize = cart.Product.ProductSizes
					.FirstOrDefault(x => x.SizeId == cart.SizeId && x.ProductId == cart.ProductId);
				if (cart.Quantity > productSize.Quantity)
				{
					errorMessage += "Cart Quantity(" + cart.Quantity + ") is exceed Product Quantity(" + productSize.Quantity + ")<br/>";
					errorMessage += "Product Name: " + cart.Product.ProductName + "<br/>";
					errorMessage += "Size Name: " + productSize.Size.SizeName + "<br/>";
					errorMessage += "------------------------------------------------<br/>";
				}

			}
			return errorMessage;
		}

		public static string IsProductAvailable(List<OrderDetail> orderDetailList)
		{
			string errorMessage = "";
			foreach (OrderDetail orderDetail in orderDetailList)
			{
				ProductSize productSize = orderDetail.Product.ProductSizes
					.FirstOrDefault(x => x.SizeId == orderDetail.SizeId && x.ProductId == orderDetail.ProductId);
				if (orderDetail.Quantity > productSize.Quantity)
				{
					errorMessage += "Order Detail Quantity(" + orderDetail.Quantity + ") is exceed Product Quantity(" + productSize.Quantity + ")<br/>";
					errorMessage += "Product Name: " + orderDetail.Product.ProductName + "<br/>";
					errorMessage += "Size Name: " + productSize.Size.SizeName + "<br/>";
					errorMessage += "------------------------------------------------<br/>";
				}

			}
			return errorMessage;
		}
	}
}
