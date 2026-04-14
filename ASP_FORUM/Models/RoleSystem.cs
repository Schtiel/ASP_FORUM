using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP_FORUM.Models
{
	public class Role
	{
		public int Id { get; set; }

		[Required, StringLength(32)]
		public string Name { get; set; } = string.Empty;

		public ICollection<RolePermission> Permissions { get; set; } = [];
		public ICollection<UserRole> Users { get; set; } = [];
	}

	public class Permission
	{
		public int Id { get; set; }

		[Required, StringLength(64)]
		public string Code { get; set; } = string.Empty;
	}

	public class UserRole
	{
		public int UserId { get; set; }
		public User User { get; set; } = null!;

		public int RoleId { get; set; }
		public Role Role { get; set; } = null!;
	}

	public class RolePermission
	{
		public int RoleId { get; set; }
		public Role Role { get; set; } = null!;

		public int PermissionId { get; set; }
		public Permission Permission { get; set; } = null!;
	}
}