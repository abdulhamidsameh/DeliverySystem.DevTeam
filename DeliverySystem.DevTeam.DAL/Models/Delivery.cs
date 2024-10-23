namespace DeliverySystem.DevTeam.DAL.Models
{
	public class Delivery : BaseEntity
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string Address { get; set; }
	}
}
