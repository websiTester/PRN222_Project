using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetAllVoucherService : IGetAllVoucherService
	{
		private IGetAllVoucherRepository _repository;
		public GetAllVoucherService(IGetAllVoucherRepository repository)
		{
			_repository = repository;
		}
		public List<Voucher> GetAllVoucher()
		{
			return _repository.GetAllVoucher();
		}
	}
}
