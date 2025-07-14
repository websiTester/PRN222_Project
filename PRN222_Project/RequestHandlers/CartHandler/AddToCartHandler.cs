using Microsoft.AspNetCore.Identity;
using PRN222_Project.Models;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.RequestHandlers.CartHandler
{
	public class AddToCartHandler
	{
		public static string AddToCart(ISession session, User user,
			IGetCartByUserId_ProductId_SizeIdService getCartByUserId_ProductId_SizeIdService,
			int productId, int sizeId, int quantity,
			IAddToCartService addToCartService,
			IGetProductByIdService getProductByIdService,
			IUpdateCartService updateCartService)
		{
			
			string? errorMessage = "";
			Cart? cartExist = getCartByUserId_ProductId_SizeIdService
				.GetCartByUserId_ProductId_SizeId(user.Id, productId, sizeId);

			if (cartExist == null)
			{
				cartExist = new Cart()
				{
					UserId = user.Id,
					ProductId = productId,
					SizeId = sizeId,
					Quantity = quantity
				};
				int totalCart = session.GetInt32("TotalCart") ?? 0;
				session.SetInt32("TotalCart", totalCart + 1);
				addToCartService.AddToCart(cartExist);
			}
			else
			{
				int? newQuantity = cartExist.Quantity + quantity;

				Product product = getProductByIdService.GetProductById(productId);
				ProductSize productSize = product.ProductSizes
					.FirstOrDefault(ps => ps.SizeId == sizeId);

				if (productSize.Quantity < newQuantity)
				{
					errorMessage = "Total Number of Products in Cart is exceed the Product Quantity!";
				}
				else
				{
					cartExist.Quantity = newQuantity;
					updateCartService.UpdateCart(cartExist);
					errorMessage = "";
				}
			}
			return errorMessage;
		}
	}
}
