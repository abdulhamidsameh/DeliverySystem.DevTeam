namespace DeliverySystem.DevTeam.PL.Helpers
{
	public class ApplicationUserClaimsFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
	{
		public ApplicationUserClaimsFactory(UserManager<ApplicationUser> userManager,
			RoleManager<ApplicationRole> roleManager,
			IOptions<IdentityOptions> options)
			: base(userManager, roleManager, options)
		{
		}
		protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
		{
			var identity = await base.GenerateClaimsAsync(user);
			identity.AddClaim(new Claim(ClaimTypes.GivenName, user.FullName));
			return identity;
		}
	}
}
