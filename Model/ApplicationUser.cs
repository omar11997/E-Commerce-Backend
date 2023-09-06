using Microsoft.AspNetCore.Identity;

namespace Karem_Ecommerce.Model
{
	public class ApplicationUser : IdentityUser
	{
		public string Image { get; set; } = string.Empty;
	}
}
