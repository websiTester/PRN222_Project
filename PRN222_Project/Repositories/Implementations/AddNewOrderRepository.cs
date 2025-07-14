using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class AddNewOrderRepository : IAddNewOrderRepository
	{
		private IDBContext _context;
		public AddNewOrderRepository(IDBContext context)
		{
			_context = context;
		}
		public async Task<Order> AddNewOrder(Order order)
		{
			order =  (await _context.GetContext().Orders.AddAsync(order)).Entity;
			_context.GetContext().SaveChanges();
			return order;
		}
	}
}
