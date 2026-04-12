using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ASP_FORUM.Models;
using ASP_FORUM.Services;

namespace ASP_FORUM.Pages.Users
{
	public class CreateModel(UserService service) : PageModel
	{
		private readonly UserService _service = service;

		[BindProperty]
		public required User Input { get; set; } // Usare un RegisterForm no quiero usar la clase general

		public void OnGet() { }

		public async Task<IActionResult> OnPostAsync()
		{
			if (User == null || !ModelState.IsValid)
				return Page();
			await _service.CreateAsync(Input);
			return RedirectToPage("Index");
		}
	}
}
