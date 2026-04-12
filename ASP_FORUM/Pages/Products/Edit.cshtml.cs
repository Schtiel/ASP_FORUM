using ASP_FORUM.Models;
using ASP_FORUM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_FORUM.Pages.Products
{
	public class EditModel(ProductService service) : PageModel
	{
		private readonly ProductService _service = service;

		[BindProperty]
		public Product? Input { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			var product = await _service.GetByIdAsync(id);

			if (product == null)
				return NotFound();

			Input = product;
			return Page();
		}

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || Input == null)
				return Page();

			await _service.UpdateAsync(Input);
			return RedirectToPage("Index");
		}
	}
}
