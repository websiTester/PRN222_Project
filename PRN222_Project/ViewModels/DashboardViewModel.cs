using PRN222_Project.Models;

namespace PRN222_Project.ViewModels
{
	public class DashboardViewModel
	{
		public DateTime? FromDate { get; set; }
		public DateTime? ToDate { get; set; }
		public int TotalUsers { get; set; }
		public int TotalProducts { get; set; }
		public int TotalOrders { get; set; }
		public int TotalRevenue { get; set; }

		public List<OrderChart> OrderChartList { get; set; } = new List<OrderChart>();
	}
}
