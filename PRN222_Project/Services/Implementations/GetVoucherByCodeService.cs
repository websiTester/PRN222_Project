using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetVoucherByCodeService : IGetVoucherByCodeService
	{
		private IGetVoucherByCodeRepository _repository;
		public GetVoucherByCodeService(IGetVoucherByCodeRepository repository)
		{
			_repository = repository;
		}
		public Voucher GetVoucherByCode(string code)
		{
			return _repository.GetVoucherByCode(code);
		}
	}
}
