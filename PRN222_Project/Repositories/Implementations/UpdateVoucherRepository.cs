using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class UpdateVoucherRepository : IUpdateVoucherRepository
	{
		private IDBContext _context;
		public UpdateVoucherRepository(IDBContext context)
		{
			_context = context;
		}
		public void UpdateVoucher(Voucher voucher)
		{
			_context.GetContext().Vouchers.Update(voucher);
			_context.GetContext().SaveChanges();
		}
	}
}
