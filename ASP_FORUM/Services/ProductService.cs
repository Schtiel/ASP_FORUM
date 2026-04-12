using Microsoft.EntityFrameworkCore;
using ASP_FORUM.Data;
using ASP_FORUM.Models;

namespace ASP_FORUM.Services
{
	public class ProductService(AppDbContext context, ILogger<ProductService> logger)
	{
		private readonly AppDbContext _context = context;
		private readonly ILogger<ProductService> _logger = logger;

		public async Task<List<Product>> GetAllAsync()
		{
			return await _context.Products
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<Product?> GetByIdAsync(int id)
		{
			return await _context.Products
				.AsNoTracking()
				.FirstOrDefaultAsync(p => p.Id == id);
		}

		public async Task CreateAsync(Product product)
		{
			_logger.LogInformation("DB:Creando producto {Name}", product.Name);

			_context.Products.Add(product);
			await _context.SaveChangesAsync();

			_logger.LogInformation("DB:Producto {Name} creado con ID {Id}", product.Name, product.Id);
		}

		public async Task UpdateAsync(Product product)
		{
			_logger.LogInformation("DB:Actualizando producto con ID {Id}", product.Id);

			_context.Products.Update(product);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			_logger.LogInformation("DB:Eliminando producto con ID {Id}", id);

			var product = await _context.Products.FindAsync(id);

			if (product is null)
				return;

			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
		}
	}
}
