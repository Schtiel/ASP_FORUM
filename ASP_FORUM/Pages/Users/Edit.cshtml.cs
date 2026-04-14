using ASP_FORUM.Models;
using ASP_FORUM.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_FORUM.Pages.Users
{
	public class EditModel(UserService service) : PageModel
	{
		private readonly UserService _service = service;

		[BindProperty]
		public User? Input { get; set; }

		public async Task<IActionResult> OnGetAsync(int id)
		{
			var User = await _service.GetByIdAsync(id);

			if (User == null)
				return NotFound();

			Input = User;
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
