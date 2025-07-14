using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;

namespace PRN222_Project.Repositories.Implementations
{
	public class UpdateProductSizeRepository : IUpdateProductSizeRepository
	{
		private IDBContext _context;
		public UpdateProductSizeRepository(IDBContext context)
		{
			_context = context;
		}
		public void UpdateProductSize(ProductSize productSize)
		{
			_context.GetContext().ProductSizes.Update(productSize);
			_context.GetContext().SaveChanges();
		}
	}
}
