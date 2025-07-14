using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class DeleteAddressByIdRepository : IDeleteAddressByIdRepository
	{
		private IDBContext _context;
		public DeleteAddressByIdRepository(IDBContext context)
		{
			_context = context;
		}
		public void DeleteAddressById(int id)
		{
			CustomerAddress address = _context.GetContext().CustomerAddresses.Find(id);
			_context.GetContext().CustomerAddresses.Remove(address);
			_context.GetContext().SaveChanges();
		}
	}
}
