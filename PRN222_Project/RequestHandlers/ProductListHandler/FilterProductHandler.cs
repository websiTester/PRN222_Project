using PagedList;
using PRN222_Project.ViewModels;

namespace PRN222_Project.RequestHandlers.ProductListHandler
{
	public class FilterProductHandler
	{
		public static void FilterProduct(ProductListViewModel model, int? page)
		{
			model.ProductListFilter = model.ProductList;

			List<String> categoryIds = model.CategorieList.Where(c => c.IsSelected)
										.Select(c => c.CategoryId.ToString()).ToList();
			List<String> brandIds = model.BrandList.Where(b => b.IsSelected)
									.Select(b => b.BrandId.ToString()).ToList();


			//Filter Name
			if (string.IsNullOrEmpty(model.SearchName)==false)
			{
				model.ProductListFilter = model.ProductListFilter.Where(p => 
				p.ProductName.ToLower().Contains(model.SearchName.ToLower())).ToList();
			}


			//Filter Category
			if (categoryIds.Any())
			{
				model.ProductListFilter = model.ProductListFilter.Where(p => (
				categoryIds.Contains(p.ProductCategoryId.ToString())
				)).ToList();
			}


			//Filter Brand
			if (brandIds.Any())
			{			
				model.ProductListFilter = model.ProductListFilter.Where(p => (
									brandIds.Contains(p.BrandId.ToString())
									)).ToList();

			}


			//Sort List
			if(model.SortBy == "low")
			{
				model.ProductListFilter = model.ProductListFilter
					.OrderBy(p => p.Price).ToList();
			} else if(model.SortBy == "high")
			{
				model.ProductListFilter = model.ProductListFilter
					.OrderByDescending(p => p.Price).ToList();
			}
			else if(model.SortBy == "rate")
			{
				 model.ProductListFilter = model.ProductListFilter
					.OrderByDescending(p => p.RatedStar).ToList();
			}


			//Filter Price
			if(model.FromPrice != null)
			{
				model.ProductListFilter = model.ProductListFilter
					.Where(p => p.Price >= model.FromPrice).ToList();
			}
			if(model.ToPrice != null)
			{
				model.ProductListFilter = model.ProductListFilter
					.Where(p => p.Price <= model.ToPrice).ToList();
			}

			//Paging: If page == null => page = 1
			//Each page show 6 product
			int pageSize = 6;
			model.ProductListFilterPaging = model.ProductListFilter
				.ToPagedList(page ?? 1, pageSize);
		
		}
	}
}
