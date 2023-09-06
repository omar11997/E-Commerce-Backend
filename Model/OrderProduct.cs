using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace Karem_Ecommerce.Model
{
	public class OrderProduct 
	{
		public int Id { get; set; }

		public DateTime Date { get; set; }
		public string? ProductName { get; set; }
		public int TotalPrice { get; set; }
		[ForeignKey("ApplicationUser")]
		public string? CustmerID { get; set; }
		[ForeignKey("Product")]
		public int ProductID { get; set; }
		public virtual Product? Product { get; set; }

		public virtual ApplicationUser? User { get; set; }
		public string? OrderStatus { get; set; }
	}
}
