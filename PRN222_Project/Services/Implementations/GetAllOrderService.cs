using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class GetAllOrderService : IGetAllOrderService
	{
		private IGetAllOrderRepository _repository;
		public GetAllOrderService(IGetAllOrderRepository repository)
		{
			_repository = repository;
		}

		public List<Order> GetAllOrders()
		{
			return _repository.GetAllOrders();
		}
		public List<Order> GetAssignedOrder()
		{
			return _repository.GetAssignedOrder();
		}

		public List<Order> GetUnProcessedOrder()
		{
			return _repository.GetUnProcessedOrder();
		}
	}
}
