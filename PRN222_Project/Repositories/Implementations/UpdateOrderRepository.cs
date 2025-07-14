using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class UpdateOrderRepository : IUpdateOrderRepository
	{
		private IDBContext _context;
		public UpdateOrderRepository(IDBContext context)
		{
			_context = context;
		}
		public void UpdateOrder(Order order)
		{
			_context.GetContext().Orders.Update(order);
			_context.GetContext().SaveChanges();
		}
	}
}
