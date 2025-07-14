using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class DeleteOrderDetailRepository : IDeleteOrderDetailRepository
	{
		private IDBContext _context;
		public DeleteOrderDetailRepository(IDBContext context)
		{
			_context = context;
		}
		public async Task DeleteOrderDetail(int orderId)
		{
			List<OrderDetail> orderDetails = _context.GetContext()
				.OrderDetails.Where(o => o.OrderId == orderId).ToList();

			 _context.GetContext().OrderDetails.RemoveRange(orderDetails);
			await _context.GetContext().SaveChangesAsync();
		}
	}
}
