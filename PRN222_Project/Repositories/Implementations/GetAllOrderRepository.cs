using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetAllOrderRepository : IGetAllOrderRepository
	{
		private IDBContext _context;
		public GetAllOrderRepository(IDBContext context)
		{
			_context = context;
		}

		public List<Order> GetAllOrders()
		{
			return _context.GetContext().Orders
				.Include(o => o.OrderStatus)
				.Include(o => o.PaymentMethod)
				.Include(o => o.PaymentStatus)
				.ToList();
		}
		public List<Order> GetAssignedOrder()
		{
			return _context.GetContext().Orders
				.Where(o => o.OrderStatusId > 1)
				.Include(o => o.OrderStatus)
				.Include(o => o.PaymentMethod)
				.Include(o => o.PaymentStatus)
				.ToList();
		}

		public List<Order> GetUnProcessedOrder()
		{
			return _context.GetContext().Orders
				.Where(o => o.OrderStatusId == 1)
				.Include(o => o.OrderStatus)
				.Include(o => o.PaymentMethod)
				.Include(o => o.PaymentStatus)
				.ToList();
		}
	}
}
