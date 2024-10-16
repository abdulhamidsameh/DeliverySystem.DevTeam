using DeliverySystem.DevTeam.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.DAL.Data.Configrations
{
	internal class ApplicationUserConfigrations : IEntityTypeConfiguration<ApplicationUser>
	{
		public void Configure(EntityTypeBuilder<ApplicationUser> builder)
		{
			builder.Property(U => U.CreatedOn)
				.HasDefaultValueSql("GETDATE()");
			builder.Property(U => U.FullName)
				.HasMaxLength(100);
		}
	}
}
