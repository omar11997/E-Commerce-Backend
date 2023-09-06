using System.ComponentModel.DataAnnotations;

namespace Karem_Ecommerce.DTO
{

		public class LoginUserDto
		{
			[Required]
			public string UserName { get; set; }
			[Required]
			public string Password { get; set; }
		}
	
}
