using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class CartListViewModel
	{
		public CartListViewModel() {
			CartList = new List<Cart>();
			VoucherList = new List<Voucher>();
		}
		public List<Cart> CartList { get; set; }
		public List<Voucher> VoucherList { get; set; }
		public Voucher SelectedVoucher { get; set; }
	}
}
