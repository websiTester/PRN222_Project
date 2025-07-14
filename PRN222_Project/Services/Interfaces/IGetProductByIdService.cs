using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetProductByIdService
	{
		public Product GetProductById(int id);
	}
}
