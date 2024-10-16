using Microsoft.AspNetCore.Identity;
namespace DeliverySystem.DevTeam.DAL.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FullName { get; set; } = null!;
        public bool IsDeleted { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? LastUpdatedOn { get; set; }
	}
}
