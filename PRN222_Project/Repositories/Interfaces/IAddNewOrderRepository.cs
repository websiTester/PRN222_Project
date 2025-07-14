using PRN222_Project.Models;

namespace PRN222_Project.Repositories.Interfaces
{
	public interface IAddNewOrderRepository
	{
		public Task<Order> AddNewOrder(Order order);
	}
}
