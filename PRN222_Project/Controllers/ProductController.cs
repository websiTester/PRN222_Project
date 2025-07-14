using Microsoft.AspNetCore.Mvc;
using PRN222_Project.Models;
using PRN222_Project.RequestHandlers.ProductDetailHandler;
using PRN222_Project.RequestHandlers.ProductListHandler;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;
using System.Text.Json.Serialization;

namespace PRN222_Project.Controllers
{
	public class ProductController : Controller
	{

		private IGetProductListService _getProductListService;
		private IGetAllBrandService _getAllBrandService;
		private IGetAllCategoriesService _getAllCategoriesService;
		private IGetProductByIdService _getProductByIdService;

		public ProductController(
			IGetProductListService getProductListService,
			IGetAllBrandService getAllBrandService, 
			IGetAllCategoriesService getAllCategoriesService,
			IGetProductByIdService getProductByIdService)
		{
			_getProductListService = getProductListService;
			_getAllBrandService = getAllBrandService;
			_getAllCategoriesService = getAllCategoriesService;
			_getProductByIdService = getProductByIdService;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			ProductListViewModel model = LoadProductListHandler.LoadProductList(
				_getProductListService, _getAllBrandService, _getAllCategoriesService);

			return View(model);
		}

		public IActionResult ProductFilterList(ProductListViewModel model, int? page)
		{

			FilterProductHandler.FilterProduct(model, page);
			
			return View("ProductList",model);
		}

		public IActionResult ProductDetail(int productId, int? sizeId, string? errorMessage)
		{
			ProductDetailViewModel model = ProductDetailHandler
				.GetProductDetailViewModel(productId, sizeId, 
				_getProductByIdService, _getProductListService);

			errorMessage = errorMessage == null ? "" : errorMessage;
			ModelState.AddModelError("", errorMessage);
			return View(model);
		}
	}
}
