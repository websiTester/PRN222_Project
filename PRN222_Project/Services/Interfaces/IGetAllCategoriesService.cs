using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetAllCategoriesService
	{
		List<ProductCategory> GetAllCategories();
	}
}
