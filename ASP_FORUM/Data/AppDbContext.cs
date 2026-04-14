using Microsoft.EntityFrameworkCore;
using ASP_FORUM.Models;

namespace ASP_FORUM.Data
{
	public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserRole>()
				.HasKey(ur => new { ur.UserId, ur.RoleId });

			modelBuilder.Entity<UserRole>()
				.HasOne(ur => ur.User)
				.WithMany(u => u.UserRoles)
				.HasForeignKey(ur => ur.UserId);

			modelBuilder.Entity<UserRole>()
				.HasOne(ur => ur.Role)
				.WithMany(r => r.Users)
				.HasForeignKey(ur => ur.RoleId);

			modelBuilder.Entity<RolePermission>()
				.HasKey(rp => new { rp.RoleId, rp.PermissionId });

			modelBuilder.Entity<RolePermission>()
				.HasOne(rp => rp.Role)
				.WithMany(r => r.Permissions)
				.HasForeignKey(rp => rp.RoleId);

			modelBuilder.Entity<RolePermission>()
				.HasOne(rp => rp.Permission)
				.WithMany()
				.HasForeignKey(rp => rp.PermissionId);

			DbSeeder.SeedModelBuilder(modelBuilder);
		}
	}
}