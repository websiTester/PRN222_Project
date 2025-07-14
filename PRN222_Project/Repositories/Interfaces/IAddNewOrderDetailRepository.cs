using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IAddNewOrderDetailRepository
	{
		public Task AddNewOrderDetail(List<OrderDetail> orderDetailList);
	}
}
