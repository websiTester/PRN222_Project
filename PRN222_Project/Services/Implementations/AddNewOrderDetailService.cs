using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class AddNewOrderDetailService : IAddNewOrderDetailService
	{
		private IAddNewOrderDetailRepository _repository;
		public AddNewOrderDetailService(IAddNewOrderDetailRepository repository)
		{
			_repository = repository;
		}
		public async Task AddNewOrderDetail(List<OrderDetail> orderDetailList)
		{
			await _repository.AddNewOrderDetail(orderDetailList);
		}
	}
}
