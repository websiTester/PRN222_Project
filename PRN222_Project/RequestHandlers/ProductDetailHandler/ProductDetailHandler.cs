using PRN222_Project.Models;
using PRN222_Project.Services.Implementations;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;

namespace PRN222_Project.RequestHandlers.ProductDetailHandler
{
	public class ProductDetailHandler
	{
		public static ProductDetailViewModel GetProductDetailViewModel(
			int productId, int? sizeId,
			IGetProductByIdService getProductByIdService,
			IGetProductListService getProductListService)
		{
			Product? product = getProductByIdService.GetProductById(productId);
			ProductDetailViewModel model = new ProductDetailViewModel()
			{
				Product = product
			};
			if (sizeId == null)
			{
				model.SelectedSizeId = product.ProductSizes.FirstOrDefault().SizeId;
				model.ProductSizeQuantity = product.ProductSizes.FirstOrDefault().Quantity;
			}
			else
			{
				model.SelectedSizeId = sizeId;
				model.ProductSizeQuantity = product.ProductSizes.FirstOrDefault(x => x.SizeId == sizeId).Quantity;
			}

			model.RelatedProductList = getProductListService.GetProductList()
				.Where(p => (p.ProductCategoryId == product.ProductCategoryId
				&& p.ProductId != product.ProductId)).Take(3).ToList();

			return model;
		}
	}
}
