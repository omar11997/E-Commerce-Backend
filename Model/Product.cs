using System.ComponentModel.DataAnnotations;

namespace Karem_Ecommerce.Model
{
	public class Product
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; } = string.Empty;
		[Required]
		public int Price { get; set; }	
		public string Description { get; set; } = string.Empty;
		public string Category { get; set; } = string.Empty;
		[Required]
		public int	Stock { get; set; }
		
	}
}
