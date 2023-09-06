using System.ComponentModel.DataAnnotations;

namespace Karem_Ecommerce.DTO
{
	public class RigsterUserDTO
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		
		public string Image { get; set; } = string.Empty;
		 public string PhoneNumeber { get; set; }

		[Compare("Password")]
		public string PasswordConfirmed { get; set; }
	}
}
