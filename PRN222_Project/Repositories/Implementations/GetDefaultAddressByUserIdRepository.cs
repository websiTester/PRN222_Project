using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetDefaultAddressByUserIdRepository : IGetDefaultAddressByUserIdRepository
	{
		private IDBContext _context;
		public GetDefaultAddressByUserIdRepository(IDBContext context)
		{
			_context = context;
		}
		public CustomerAddress GetDefaultAddressByUserId(string userId)
		{
			return _context.GetContext().CustomerAddresses
				.FirstOrDefault(a => a.IsDefault == true && a.UserId == userId);
		}
	}
}
