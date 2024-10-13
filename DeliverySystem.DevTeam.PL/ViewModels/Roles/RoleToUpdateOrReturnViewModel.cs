namespace DeliverySystem.DevTeam.PL.ViewModels.Roles
{
	public class RoleToUpdateOrReturnViewModel
	{
        public string Id { get; set; }
        public string Name { get; set; }
		public bool IsDeleted { get; set; }
		public DateTime CreatedOn { get; set; }
		public DateTime? LastUpdatedOn { get; set; }
	}
}
