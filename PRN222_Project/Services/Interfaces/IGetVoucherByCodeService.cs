using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetVoucherByCodeService
	{
		Voucher GetVoucherByCode(string code);
	}
}
