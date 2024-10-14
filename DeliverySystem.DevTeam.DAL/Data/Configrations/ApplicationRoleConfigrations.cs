using DeliverySystem.DevTeam.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DeliverySystem.DevTeam.DAL.Data.Configrations
{
    internal class ApplicationRoleConfigrations : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.Property(R => R.CreatedOn)
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
