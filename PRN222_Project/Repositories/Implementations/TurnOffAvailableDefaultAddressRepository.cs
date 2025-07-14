using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class TurnOffAvailableDefaultAddressRepository : ITurnOffAvailableDefaultAddressRepository
	{
		private IDBContext _context;
		public TurnOffAvailableDefaultAddressRepository(IDBContext context)
		{
			_context = context;
		}
		public void TurnOffAvailableDefaultAddress(string userId)
		{
			CustomerAddress address = _context.GetContext().CustomerAddresses
				.Where(a => a.IsDefault == true && a.UserId == userId).FirstOrDefault();

			if(address != null)
			{
				address.IsDefault = false;
				_context.GetContext().SaveChanges();
			}
		}
	}
}
