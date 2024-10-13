using DeliverySystem.DevTeam.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
namespace DeliverySystem.DevTeam.DAL.Data
{
	public class ApplicationDbContext :IdentityDbContext<ApplicationUser,ApplicationRole,string>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
		
		public DbSet<Product> Products { get; set; }
		public DbSet<Merchant> Merchants { get; set; }
	}
}
