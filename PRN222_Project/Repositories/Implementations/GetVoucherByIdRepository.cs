using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetVoucherByIdRepository : IGetVoucherByIdRepository
	{
		private IDBContext _context;
		public GetVoucherByIdRepository(IDBContext context)
		{
			_context = context;
		}
		public Voucher GetVoucherById(int id)
		{
			return _context.GetContext().Vouchers.Find(id);
		}
	}
}
