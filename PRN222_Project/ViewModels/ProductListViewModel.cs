using PagedList;
using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class ProductListViewModel
	{
		public ProductListViewModel()
		{
			ProductList = new List<Product>();
			CategorieList = new List<CategoryViewModel>();
			BrandList = new List<BrandViewModel>();
			ProductListFilter = new List<Product>();
		}

		public IPagedList<Product> ProductListFilterPaging { get; set; }
		public List<Product> ProductList { get; set; }
		public List<Product> ProductListFilter { get; set; }
		public List<CategoryViewModel> CategorieList { get; set; }
		public List<BrandViewModel> BrandList { get; set; }
		public string? SearchName { get; set; }
		public string? SortBy { get; set; }
		public int? FromPrice { get; set; }
		public int? ToPrice { get; set; }
		public int? TotalPage { get; set; }
	}
}
