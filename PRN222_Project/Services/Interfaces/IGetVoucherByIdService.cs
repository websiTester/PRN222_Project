using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IGetVoucherByIdService
	{
		Voucher GetVoucherById(int id);
	}
}
