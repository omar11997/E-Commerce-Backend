using Karem_Ecommerce.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Karem_Ecommerce.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly Context context;
		public ProductController(Context context)
		{
			this.context = context;
		}
		[HttpGet]
		public IActionResult Getall()
		{
			List<Product> alldeps = context.products.ToList();

			return Ok(alldeps);
		}
		[HttpGet]
		[Route("{id:int}")]

		public IActionResult GetById(int id)
		{
			Product department = context.products.FirstOrDefault(d => d.Id == id);
			if (department != null)
			{
				return Ok(department);

			}
			return NotFound();
		}
		[HttpPost]
		public IActionResult Add(Product pro)
		{
			if (pro != null)
			{
				context.products.Add(pro);
				context.SaveChanges();
				return Ok("ADDED");
			}
			return BadRequest();
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			Product pro = context.products.FirstOrDefault(pro => pro.Id == id);
			if (pro != null)
			{
				context.products.Remove(pro);
				context.SaveChanges();
				return Ok("REMOVED");

			}
			return NotFound(id);
		}
		//[HttpPut]
		//public IActionResult Update(int id, Product dep)
		//{
		//	Department deptochange = context.products.FirstOrDefault(dept => dept.Id == id);
		//	if (deptochange != null)
		//	{
		//		deptochange.Name = dep.Name;
		//		deptochange.Manager = dep.Manager;
		//		context.SaveChanges();
		//		return Ok("UPDATED");

		//	}
		//	return NotFound(id);
		//}
	}
}
