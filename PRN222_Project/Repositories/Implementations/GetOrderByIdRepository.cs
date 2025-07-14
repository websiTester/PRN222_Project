using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetOrderByIdRepository : IGetOrderByIdRepository
	{
		private IDBContext _context;
		public GetOrderByIdRepository(IDBContext context)
		{
			_context = context;
		}
		public Order GetOrderById(int orderId)
		{
			return _context.GetContext().Orders.Include(o => o.OrderStatus)
				.Include(o => o.PaymentStatus)
				.Include(o => o.PaymentMethod)
				.Include(o => o.Voucher)
				.Include(o => o.OrderDetails).ThenInclude(od => od.Product).ThenInclude(p => p.ProductSizes)
				.Include(o => o.OrderDetails).ThenInclude(od => od.Size)
				.Include(o => o.CustomerAddress)
				.FirstOrDefault(o => o.OrderId == orderId);
		}
	}
}
