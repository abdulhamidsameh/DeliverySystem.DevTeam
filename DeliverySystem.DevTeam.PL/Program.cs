using DeliverySystem.DevTeam.PL.Extensions;

namespace DeliverySystem.DevTeam.PL
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add Application Service To DI Container
			ApplicationServicesExtension.ApplicationServices(builder.Services, builder.Configuration);

			var app = builder.Build();
			var scope = app.Services.CreateScope();
			var services = scope.ServiceProvider;
			var _dbcontext = services.GetRequiredService<ApplicationDbContext>();
			var roleManger = services.GetRequiredService<RoleManager<ApplicationRole>>();
			var userManger = services.GetRequiredService<UserManager<ApplicationUser>>();
			var _loogerFactory = services.GetRequiredService<ILoggerFactory>();
			try
			{
				await _dbcontext.Database.MigrateAsync();
				await DefaultRoles.SeedAsync(roleManger);
				await DefaultUsers.SeedAdminUserAsync(userManger);
			}
			catch (Exception ex)
			{
				var logger = _loogerFactory.CreateLogger<Program>();
				logger.LogError(ex, "an Error Has Been Occured during applay Database");
			}
			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseExceptionHandler("/Home/Error");

			app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseCookiePolicy(new CookiePolicyOptions()
			{
				Secure = CookieSecurePolicy.Always,
			});

			app.Use(async (context, next) =>
			{
				context.Response.Headers.Add("X-Frame-Options", "Deny");

				await next();
			});

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();



			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();
				endpoints.MapControllers();
			});

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
