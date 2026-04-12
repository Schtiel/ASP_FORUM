using ASP_FORUM.Models;
using ASP_FORUM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_FORUM.Pages.Products
{
	public class CreateModel(ProductService service) : PageModel
	{
		private readonly ProductService _service = service;

		[BindProperty]
		public required Product Input { get; set; }

		public void OnGet() { }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
				return Page();

			await _service.CreateAsync(Input);
			return RedirectToPage("Index");
		}
	}
}
