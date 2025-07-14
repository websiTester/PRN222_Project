using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetAllVoucherRepository : IGetAllVoucherRepository
	{
		private IDBContext _context;
		public GetAllVoucherRepository(IDBContext context)
		{
			_context = context;
		}
		public List<Voucher> GetAllVoucher()
		{
			DateOnly now = DateOnly.FromDateTime(DateTime.Now);
			return _context.GetContext().Vouchers
				.Where(vc => vc.EndDate >= now && vc.IsActive==true)
				.Take(4)
				.ToList();
		}
	}
}
