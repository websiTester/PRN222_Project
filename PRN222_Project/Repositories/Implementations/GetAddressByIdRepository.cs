using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetAddressByIdRepository : IGetAddressByIdRepository
	{
		private IDBContext _context;
		public GetAddressByIdRepository(IDBContext context)
		{
			_context = context;
		}
		public CustomerAddress GetAddressById(int id)
		{
			return _context.GetContext().CustomerAddresses.Find(id);
		}
	}
}
