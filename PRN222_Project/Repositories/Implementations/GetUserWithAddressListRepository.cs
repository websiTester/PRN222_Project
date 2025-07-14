using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetUserWithAddressListRepository : IGetUserWithAddressListRepository
	{
		private IDBContext _context;
		public GetUserWithAddressListRepository(IDBContext context)
		{
			_context = context;
		}
		public User GetUserWithAddressList(string userId)
		{
			return _context.GetContext().Users
				.Include(u => u.CustomerAddresses).FirstOrDefault(u => u.Id == userId);
		}
	}
}
