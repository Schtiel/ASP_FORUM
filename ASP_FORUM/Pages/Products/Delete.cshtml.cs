using ASP_FORUM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_FORUM.Pages.Products
{
	public class DeleteModel : PageModel
	{
		private readonly ProductService _service;

		public DeleteModel(ProductService service)
		{
			_service = service;
		}

		public async Task<IActionResult> OnGetAsync(int id)
		{
			await _service.DeleteAsync(id);
			return RedirectToPage("Index");
		}
	}
}
