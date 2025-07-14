using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetDefaultAddressByUserIdRepository
	{
		CustomerAddress GetDefaultAddressByUserId(string userId);
	}
}
