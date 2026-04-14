using ASP_FORUM.Data;
using ASP_FORUM.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<UserService>();

// Add services to the container.
builder.Services.AddRazorPages();

// Crear archivo de log, consola + archivo.
Log.Logger = new LoggerConfiguration().MinimumLevel.Information()

	// LOG GENERAL (app)
	.WriteTo.File(
		"logs/app-.txt",
		rollingInterval: RollingInterval.Day
	)

	// ERRORES
	.WriteTo.File(
		"logs/errors-.txt",
		rollingInterval: RollingInterval.Day,
		restrictedToMinimumLevel: LogEventLevel.Error
	)

	// DB 
	.WriteTo.Logger(lc => lc
		.Filter.ByIncludingOnly(e =>
			e.MessageTemplate.Text.Contains("DB:"))
		.WriteTo.File(
			"logs/db-.txt",
			rollingInterval: RollingInterval.Day
		)
	)

	.WriteTo.Console()
	.CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseMiddleware<ExceptionMiddleware>(); // Control de errores

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapGet("/test-error", () =>
{
	throw new Exception("Error forzado");
});

// Sistema de migración, para crear y actualizar las DB sin tener que usar archivos .sql
using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
	db.Database.Migrate();
}

app.Run();
