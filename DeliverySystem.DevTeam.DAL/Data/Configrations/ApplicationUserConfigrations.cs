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
            builder.HasIndex(U => U.Email)
                .IsUnique(true);
            builder.HasIndex(U => U.UserName)
                .IsUnique(true);
        }
    }
}
