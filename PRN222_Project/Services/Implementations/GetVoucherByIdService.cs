using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetVoucherByIdService : IGetVoucherByIdService
	{
		private IGetVoucherByIdRepository _repository;
		public GetVoucherByIdService(IGetVoucherByIdRepository repository)
		{
			_repository = repository;
		}
		public Voucher GetVoucherById(int id)
		{
			return _repository.GetVoucherById(id);
		}
	}
}
