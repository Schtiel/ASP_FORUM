using ASP_FORUM.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_FORUM.Data
{
	public static class DbSeeder
	{
		public static void SeedModelBuilder(ModelBuilder modelBuilder) // Llamado desde: AppDbContext.OnModelCreating(ModelBuilder modelBuilder)
		{
			// Roles
			modelBuilder.Entity<Role>().HasData(
				new Role { Id = 1, Name = "Guest" },
				new Role { Id = 2, Name = "User" },
				new Role { Id = 3, Name = "Moderator" },
				new Role { Id = 4, Name = "Administrator" }
			);

			// Usuario Administrador por defecto
			// ...
		}
	}
}
