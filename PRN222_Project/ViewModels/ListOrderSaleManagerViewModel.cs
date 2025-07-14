using PagedList;
using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class ListOrderSaleManagerViewModel
	{
		public List<Order> OrderList { get; set; }
		public IPagedList<Order> OrderPageList { get; set; }
		public int? OrderType { get; set; }
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public int Index { get; set; }
	}
}
