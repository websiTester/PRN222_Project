using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetAddressByIdService
	{
		CustomerAddress GetAddressById(int id);
	}
}
