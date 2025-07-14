using PRN222_Project.Models;
using PRN222_Project.Repositories.Interfaces;
using PRN222_Project.Services.Interfaces;

namespace PRN222_Project.Services.Implementations
{
	public class AddToCartService : IAddToCartService
	{
		private IAddToCartRepository _repository;
		public AddToCartService(IAddToCartRepository repository)
		{
			_repository = repository;
		}
		public void AddToCart(Cart cart)
		{
			_repository.AddToCart(cart);
		}
	}
}
