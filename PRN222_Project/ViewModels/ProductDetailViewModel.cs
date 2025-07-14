using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class ProductDetailViewModel
	{
		public ProductDetailViewModel() { RelatedProductList = new List<Product>(); }
		public Product Product { get; set; }
		public List<Product> RelatedProductList { get; set; }
		public int? SelectedSizeId { get; set; }
		public int? ProductSizeQuantity { get; set; }
	}
}
