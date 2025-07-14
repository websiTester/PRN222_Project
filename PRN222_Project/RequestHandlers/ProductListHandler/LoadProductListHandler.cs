using PagedList;
using PRN222_Project.Services.Interfaces;
using PRN222_Project.ViewModels;

namespace PRN222_Project.RequestHandlers.ProductListHandler
{
	public class LoadProductListHandler
	{

		public static ProductListViewModel LoadProductList(
			IGetProductListService _getProductListService, 
			IGetAllBrandService _getAllBrandService, 
			IGetAllCategoriesService _getAllCategoriesService)
		{
			ProductListViewModel model = new ProductListViewModel()
			{
				ProductList = _getProductListService.GetProductList(),

			};
			model.ProductListFilter = model.ProductList;
			foreach (var category in _getAllCategoriesService.GetAllCategories())
			{
				CategoryViewModel categoryViewModel = new CategoryViewModel()
				{
					CategoryId = category.ProductCategoryId,
					CategoryName = category.ProductCategoryName
				};
				model.CategorieList.Add(categoryViewModel);
			}

			foreach (var brand in _getAllBrandService.GetAllBrands())
			{
				BrandViewModel brandViewModel = new BrandViewModel()
				{
					BrandId = brand.BrandId,
					BrandName = brand.BrandName
				};
				model.BrandList.Add(brandViewModel);
			}

			model.ProductListFilterPaging =  model.ProductListFilter.ToPagedList(1, 6);
			return model;
		}

	}
}
