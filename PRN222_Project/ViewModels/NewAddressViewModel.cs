using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class NewAddressViewModel
	{
		public User User { get; set; }
		public CustomerAddress Address { get; set; }
		public string Province { get; set; }
		public string District { get; set; }
		public string Ward { get; set; }
	}
}
