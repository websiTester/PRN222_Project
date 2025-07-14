using Microsoft.EntityFrameworkCore;
using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class GetListOrderByUserIdRepository : IGetListOrderByUserIdRepository
	{
		private IDBContext _context;
		public GetListOrderByUserIdRepository(IDBContext context)
		{
			_context = context;
		}
		public List<Order> GetListOrderByUserId(string userId)
		{
			return _context.GetContext().Orders
				.Where(o => o.UserId.ToLower() == userId.ToLower())
				.Include(o => o.OrderStatus)
				.Include(o => o.PaymentMethod)
				.ToList();
		}
	}
}
