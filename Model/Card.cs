namespace Karem_Ecommerce.Model
{
	public class Card
	{
		public int Id { get; set; }

		public int Quantity { get; set; }
		public virtual ICollection<Product> products { get; set; } = new List<Product>();
	}
}
