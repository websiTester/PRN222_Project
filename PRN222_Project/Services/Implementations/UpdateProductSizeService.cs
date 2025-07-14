using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class UpdateProductSizeService : IUpdateProductSizeService
	{
		private IUpdateProductSizeRepository _repository;
		public UpdateProductSizeService(IUpdateProductSizeRepository repository)
		{
			_repository = repository;
		}
		public void UpdateProductSize(ProductSize productSize)
		{
			_repository.UpdateProductSize(productSize);
		}
	}
}
