using ASP_FORUM.Models;
using ASP_FORUM.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_FORUM.Pages.Users
{
	public class IndexModel(UserService service) : PageModel
	{
		private readonly UserService _service = service;

		public List<User> Output { get; set; } = [];

		public async Task OnGetAsync()
		{
			Output = await _service.GetAllAsync();
		}
	}
}


