using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class CheckoutViewModel
	{
		public CheckoutViewModel() {
			CartList = new List<Cart>();
		}
	
		public List<Cart> CartList { get; set; }
		public Voucher SelectedVoucher { get; set; }
		public CustomerAddress DefaultAddress { get; set; }

	}
}
