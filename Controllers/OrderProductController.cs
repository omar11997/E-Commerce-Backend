using Karem_Ecommerce.DTO;
using Karem_Ecommerce.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Karem_Ecommerce.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class OrderProductController : ControllerBase
	{
		private readonly Context context;
		private readonly UserManager<ApplicationUser> userManager;
		public OrderProductController(Context context, UserManager<ApplicationUser> userManager)
		{
			this.context = context;
			this.userManager = userManager;	

		}
		[HttpPost]
	
		[Route("{id:int}")]
		public IActionResult Add(int id)
		{
			Product? product = context.products.FirstOrDefault(x => x.Id == id);	
			if(product != null && product.Stock >0)
			{

				OrderProduct newOrder = new OrderProduct();
				newOrder.TotalPrice = product.Price;
				newOrder.ProductID = id;
				newOrder.OrderStatus = "Pending";
				newOrder.ProductName = product.Name;
				newOrder.Date = DateTime.UtcNow;
				newOrder.CustmerID = userManager.GetUserId(User);
				product.Stock -= 1;
				context.orders.Add(newOrder);
				context.SaveChanges();
				return Ok("order added");

			}
			return BadRequest();
		}
		[HttpDelete]
		
		[Route("{id:int}")]
		public IActionResult Delete(int id)
		{
			OrderProduct? orderTodelete = context.orders.FirstOrDefault(o => o.Id == id);
			if (orderTodelete != null)
			{
				context.orders.Remove(orderTodelete);
				context.SaveChanges();
				return Ok("REMOVED");

			}
			return NotFound(id);
		}
		[HttpPut]
		[Authorize(Policy ="Admin")]
		[Route("{id:int}")]
		public IActionResult Update(int id, string newStatus)
		{
			OrderProduct? orderToUpdate = context.orders.FirstOrDefault(o => o.Id == id);
			if (orderToUpdate != null)
			{
				orderToUpdate.OrderStatus =newStatus;
				context.SaveChanges();
				return Ok("UPDATED");

			}
			return NotFound(id);
		}
		[HttpGet]
		public IActionResult Get()
		{
			string? id = userManager.GetUserId(User);
			List<OrderProduct>? orders = context.orders.Where(o => o.CustmerID == id).ToList();
			List<ProductToShowDTO> myorders = new List<ProductToShowDTO>();
			if (orders.Count > 0)
			{
				orders.ForEach(order => {
					ProductToShowDTO productToShowDTO = new ProductToShowDTO();
					productToShowDTO.Name = order.ProductName;
					productToShowDTO.Price = order.TotalPrice;
					productToShowDTO.OrderStatus = order.OrderStatus;
					myorders.Add(productToShowDTO);
					
				});
				return Ok(myorders);
			}

			return Ok("Empty");
		}
	}
}
