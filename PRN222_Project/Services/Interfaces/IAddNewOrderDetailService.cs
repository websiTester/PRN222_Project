using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IAddNewOrderDetailService
	{
		public Task AddNewOrderDetail(List<OrderDetail> orderDetailList);
	}
}
