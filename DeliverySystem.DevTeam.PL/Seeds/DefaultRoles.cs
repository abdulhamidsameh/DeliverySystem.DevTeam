namespace DeliverySystem.DevTeam.PL.Seeds
{
	public static class DefaultRoles
	{
		public static async Task SeedAsync(RoleManager<ApplicationRole> roleManager)
		{
			if (!roleManager.Roles.Any())
			{
				await roleManager.CreateAsync(new ApplicationRole()
				{
					Name = AppRoles.Admin
				});
				await roleManager.CreateAsync(new ApplicationRole()
				{
					Name = AppRoles.Delivery
				});
				await roleManager.CreateAsync(new ApplicationRole()
				{
					Name = AppRoles.Merchant
				});
				await roleManager.CreateAsync(new ApplicationRole()
				{
					Name = AppRoles.WarehouseStaff
				});
				await roleManager.CreateAsync(new ApplicationRole()
				{
					Name = AppRoles.WarehouseManger
				});
			}
		}
	}
}