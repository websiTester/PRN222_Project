using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetProductByIdRepository
	{
		Product GetProductById(int id);
	}
}
