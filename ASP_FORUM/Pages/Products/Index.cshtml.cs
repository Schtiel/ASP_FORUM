using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_FORUM.Models;
using ASP_FORUM.Services;

namespace ASP_FORUM.Pages.Products
{
	public class IndexModel : PageModel
	{
		private readonly ProductService _service;

		public IndexModel(ProductService service)
		{
			_service = service;
		}

		public List<Product> Products { get; set; }

		public async Task OnGetAsync()
		{
			Products = await _service.GetAllAsync();
		}
	}
}
