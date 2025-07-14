using PRN222_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN222_Project.ViewModels
{
	public class EditRoleViewModel
	{

		public EditRoleViewModel() { UserList = new List<User>(); }
		public string Id { get; set; }

		[Required(ErrorMessage = "Role Name is required")]
		public string RoleName { get; set; }

		public List<User> UserList { get; set; }
	}
}
