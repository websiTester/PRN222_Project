using PagedList;
using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class OrderHistoryViewModel
	{
		public OrderHistoryViewModel()
		{
			OrderList = new List<Order>();
		}
		public List<Order> OrderList { get; set; }
		public IPagedList<Order> OrderPageList { get; set; }
		public User User { get; set; }
		public int Index { get; set; }
	}
}
