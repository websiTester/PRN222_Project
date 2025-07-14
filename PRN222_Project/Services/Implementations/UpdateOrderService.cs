using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class UpdateOrderService : IUpdateOrderService
	{
		private IUpdateOrderRepository _repository;
		public UpdateOrderService(IUpdateOrderRepository repository)
		{
			_repository = repository;
		}
		public void UpdateOrder(Order order)
		{
			_repository.UpdateOrder(order);
		}
	}
}
