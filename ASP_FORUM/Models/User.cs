using System.ComponentModel.DataAnnotations;

namespace ASP_FORUM.Models
{

	public class User
	{
		public int Id { get; set; }

		[Required, StringLength(24)]
		public string Username { get; set; } = string.Empty;

		[Required, EmailAddress]
		public string Email { get; set; } = string.Empty;

		[Required]
		public string PasswordHash { get; set; } = string.Empty;

		public bool IsBanned { get; set; }
		public string? BannedReason { get; set; }
		public DateTime? BannedAt { get; set; }

		public int? BannedById { get; set; }
		public User? BannedBy { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime? LastLoginAt { get; set; }
		public DateTime LastModifiedAt { get; set; } = DateTime.UtcNow;

		public int ThreadCount { get; set; }
		public int PostCount { get; set; }

		public string? AvatarUrl { get; set; }
		public string? Bio { get; set; }

		public ICollection<UserRole> UserRoles { get; set; } = [];

		[Timestamp]
		public byte[] RowVersion { get; set; } = null!;
	}
}
