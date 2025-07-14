using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetVoucherByCodeRepository : IGetVoucherByCodeRepository
	{
		private IDBContext _context;
		public GetVoucherByCodeRepository(IDBContext context)
		{
			_context = context;
		}
		public Voucher GetVoucherByCode(string code)
		{
			return _context.GetContext().Vouchers
				.FirstOrDefault(v => v.VoucherCode.ToLower() == code.ToLower());
		}
	}
}
