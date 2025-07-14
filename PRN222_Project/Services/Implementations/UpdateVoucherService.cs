using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class UpdateVoucherService : IUpdateVoucherService
	{
		private IUpdateVoucherRepository _repository;
		public UpdateVoucherService(IUpdateVoucherRepository repository)
		{
			_repository = repository;
		}
		public void UpdateVoucher(Voucher voucher)
		{
			_repository.UpdateVoucher(voucher);
		}
	}
}
