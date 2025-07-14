using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class UpdateAddressRepository : IUpdateAddressRepository
	{
		private IDBContext _context;
		public UpdateAddressRepository(IDBContext context)
		{
			_context = context;
		}
		public void UpdateAddress(CustomerAddress address)
		{
			_context.GetContext().ChangeTracker.Clear();
			_context.GetContext().CustomerAddresses.Update(address);
			_context.GetContext().SaveChanges();
		}
	}
}
