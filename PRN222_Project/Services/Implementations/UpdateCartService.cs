using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class UpdateCartService : IUpdateCartService
	{
		private IUpdateCartRepository _repository;
		public UpdateCartService(IUpdateCartRepository repository)
		{
			_repository = repository;
		}
		public void UpdateCart(Cart cart)
		{
			_repository.UpdateCart(cart);
		}
	}
}
