namespace ASP_FORUM.Models
{
	public class User
	{
		public int Id { get; set; }

		// Identidad pública
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;

		// Seguridad
		public string PasswordHash { get; set; } = string.Empty;

		// Estado de cuenta
		public bool IsActive { get; set; } = true;
		public bool IsBanned { get; set; } = false;
		public string? BannedReason { get; set; }
		public DateTime? BannedAt { get; set; }
		public int? BannedById { get; set; }
		public User? BannedBy { get; set; }

		// Auditoría
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime? LastLoginAt { get; set; }

		// Stats
		public int ThreadCount { get; set; }
		public int PostCount { get; set; }

		// Personalización
		public string Role { get; set; } = "User";
		public string? AvatarUrl { get; set; }
		public string? Bio { get; set; }
	}
}
