namespace DeliverySystem.DevTeam.PL.Seeds
{
	public static class DefaultUsers
	{
		public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
		{
			ApplicationUser admin = new ApplicationUser()
			{
				UserName = "admin@shipFast.com",
				Email = "admin@shipFast.com",
				FullName = "Admin"
			};
			var user = await userManager.FindByEmailAsync(admin.Email);
			if(user is null)
			{
				await userManager.CreateAsync(admin,"P@ssword123");
				await userManager.AddToRoleAsync(admin, AppRoles.Admin);
			}
		}
	}
}