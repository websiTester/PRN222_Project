using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class DeleteOrderDetailService : IDeleteOrderDetailService
	{
		private IDeleteOrderDetailRepository _repository;
		public DeleteOrderDetailService(IDeleteOrderDetailRepository repository)
		{
			_repository = repository;
		}
		public async Task DeleteOrderDetail(int id)
		{
			await _repository.DeleteOrderDetail(id);
		}
	}
}
