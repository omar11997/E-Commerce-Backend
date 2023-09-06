using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Karem_Ecommerce.Model
{
	public class Context: IdentityDbContext<ApplicationUser>
	{
		public DbSet<Product> products { get; set; }
		public DbSet<OrderProduct> orders { get; set; }
		public Context() { }

		public Context(DbContextOptions options) : base(options)
		{

		}
	}
}
