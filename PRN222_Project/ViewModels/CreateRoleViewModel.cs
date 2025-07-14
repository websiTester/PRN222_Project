using System.ComponentModel.DataAnnotations;

namespace PRN222_Project.ViewModels
{
	public class CreateRoleViewModel
	{
		[Required]
		public string RoleName { get; set; }
	}
}
