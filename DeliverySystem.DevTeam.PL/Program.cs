using DeliverySystem.DevTeam.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.DevTeam.PL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();
			builder.Services.AddDbContext<ApplicationDbContext>(
				options =>
				{
					options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies();
				});
			var app = builder.Build();
			var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var _dbcontext = services.GetRequiredService<ApplicationDbContext>();
			var _loogerFactory = services.GetRequiredService<ILoggerFactory>();
			try
			{
				await _dbcontext.Database.MigrateAsync();
			}
			catch (Exception ex)
			{
				var logger = _loogerFactory.CreateLogger<Program>();
				logger.LogError(ex, "an Error Has Been Occured during applay Database");
			}
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
