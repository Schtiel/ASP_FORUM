using Microsoft.EntityFrameworkCore;
using ASP_FORUM.Models;

namespace ASP_FORUM.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<User> Users { get; set; }
	}
}