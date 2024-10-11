using DeliverySystem.DevTeam.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DeliverySystem.DevTeam.DAL.Data
{
	public class ApplicationDbContext :IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			:base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Merchant> Merchants { get; set; }
	
	}
}
