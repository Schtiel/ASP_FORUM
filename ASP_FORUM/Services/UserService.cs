using Microsoft.EntityFrameworkCore;
using ASP_FORUM.Data;
using ASP_FORUM.Models;
using ASP_FORUM.Common;

namespace ASP_FORUM.Services
{
	public class UserService(AppDbContext context, ILogger<UserService> logger)
	{
		private readonly AppDbContext _context = context;
		private readonly ILogger<UserService> _logger = logger;

		public async Task<List<User>> GetAllAsync()
		{
			return await _context.Users
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<User?> GetByIdAsync(int id)
		{
			return await _context.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task<User?> GetByUsernameAsync(string username)
		{
			return await _context.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.Username == username);
		}

		public async Task<User?> GetByEmailAsync(string username)
		{
			return await _context.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.Username == username);
		}

		public async Task<bool> CheckUserExistAsync(string username, string email)
		{
			return await _context.Users
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.Username == username || p.Email == email) != null;
		}

		public async Task<TaskResult<User>> CreateAsync(User user)
		{
			if (await CheckUserExistAsync(user.Username, user.Email))
				return TaskResult<User>.Fail("Ese usuario o correo ya esta siendo usado");

			_logger.LogInformation("DB:Creando usuario {Name}", user.Username);

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			_logger.LogInformation("DB:Usuario {Name} creado con ID {Id}", user.Username, user.Id);

			return TaskResult<User>.Ok(user);
		}

		public async Task<TaskResult> DeleteAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user is null)
				return TaskResult.Fail("Usuario no encontrado");

			_logger.LogInformation("DB:Eliminando usuario {Name}", user.Username);

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			_logger.LogInformation("DB:Usuario {Id} eliminado", id);

			return TaskResult.Ok();
		}
	}
}
