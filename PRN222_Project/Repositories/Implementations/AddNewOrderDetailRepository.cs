using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class AddNewOrderDetailRepository : IAddNewOrderDetailRepository
	{
		private IDBContext _context;
		public AddNewOrderDetailRepository(IDBContext context)
		{
			_context = context;
		}
		public async Task AddNewOrderDetail(List<OrderDetail> orderDetailList)
		{
			await _context.GetContext().OrderDetails.AddRangeAsync(orderDetailList);
			await _context.GetContext().SaveChangesAsync();
		}
	}
}
