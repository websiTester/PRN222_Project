using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class AddNewOrderService : IAddNewOrderService
	{
		private IAddNewOrderRepository _repository;
		public AddNewOrderService(IAddNewOrderRepository repository)
		{
			_repository = repository;
		}
		public async Task<Order> AddNewOrder(Order order)
		{
			return await _repository.AddNewOrder(order);
		}
	}
}
