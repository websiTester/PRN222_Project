namespace PRN222_Project.Models
{
	public class MyDBContext : IDBContext
	{
		private Prn222ProjectContext _context;

		public MyDBContext(Prn222ProjectContext context)
		{
			_context = context;
		}
		public Prn222ProjectContext GetContext()
		{
			return _context;
		}
	}
}
