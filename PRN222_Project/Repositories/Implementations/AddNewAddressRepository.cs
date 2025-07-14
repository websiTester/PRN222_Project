using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class AddNewAddressRepository : IAddNewAddressRepository
	{
		private IDBContext _context;
		public AddNewAddressRepository(IDBContext context)
		{
			_context = context;
		}
		public void AddNewAddress(CustomerAddress address)
		{
			_context.GetContext().CustomerAddresses.Add(address);
			_context.GetContext().SaveChanges();
		}
	}
}
