using PRN222_Project.Models;

namespace PRN222_Project.Services.Interfaces
{
	public interface IAddNewOrderService
	{
		public Task<Order> AddNewOrder(Order order);
	}
}
