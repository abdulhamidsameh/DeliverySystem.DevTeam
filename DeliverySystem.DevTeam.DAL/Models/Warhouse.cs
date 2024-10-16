namespace DeliverySystem.DevTeam.DAL.Models
{
	public class Warhouse : BaseEntity
    {
		public string Name { get; set; }
		public string City { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
