using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IGetVoucherByIdRepository
	{
		public Voucher GetVoucherById(int id);
	}
}
