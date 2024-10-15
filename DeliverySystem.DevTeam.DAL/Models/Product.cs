
namespace DeliverySystem.DevTeam.DAL.Models
{
	public class Product : BaseEntity
	{

		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsDeleted { get; set; }
		public decimal? Price { get; set; }
		public int? QuantityAvailable { get; set; }
		public DateTime CreatedOn { get; set; } = DateTime.Now;
		public DateTime? LastUpdatedOn { get; set; }
		public int WarhouseId { get; set; }
		public Warhouse Warhouse { get; set; }
	}
}
