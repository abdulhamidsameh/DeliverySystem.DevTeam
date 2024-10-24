namespace DeliverySystem.DevTeam.DAL.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            /// مكسل اعمل لكل واحد ملف ههههههه


            builder.Entity<OrderProduct>()
                .HasKey(op => op.Id);

            /// مكسل اعمل لكل واحد ملف ههههههه
            builder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            /// مكسل اعمل لكل واحد ملف ههههههه
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Merchant> Merchants { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Warhouse> Warehouses { get; set; }
        public DbSet<City> Citys { get; set; }
        //public DbSet<Delivery> Deliveries { get; set; }
        // Deliveries
    }

}
