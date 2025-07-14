namespace PRN222_Project.Models
{
	public class Cart
	{

		public int CartId { get; set; }
		public string UserId { get; set; }
		public int ProductId { get; set; }
		public int? Quantity { get; set; }
		public int? SizeId { get; set; }

		public User? User { get; set; }
		public Product? Product { get; set; }
		public Size? Size { get; set; }

	}
}
