using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetUserWithAddressListRepository
	{
		User GetUserWithAddressList(string userId);
	}
}
