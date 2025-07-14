using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetDefaultAddressByUserIdService
	{
		CustomerAddress GetDefaultAddressByUserId(string userId);
	}
}
