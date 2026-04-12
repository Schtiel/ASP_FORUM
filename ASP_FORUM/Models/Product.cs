using System.ComponentModel.DataAnnotations;

namespace ASP_FORUM.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; } = string.Empty;

		[Range(0.01, 999999)]
		public decimal Price { get; set; }
	}
}
