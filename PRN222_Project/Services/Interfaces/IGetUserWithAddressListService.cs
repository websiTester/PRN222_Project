using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetUserWithAddressListService
	{
		User GetUserWithAddressList(string userId);
	}
}
