using Microsoft.AspNetCore.Identity;
namespace DeliverySystem.DevTeam.DAL.Models
{
    public class ApplicationRole : IdentityRole
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } 
        public DateTime? LastUpdatedOn { get; set; }
    }
}
