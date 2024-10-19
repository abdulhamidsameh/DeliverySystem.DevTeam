using System.ComponentModel.DataAnnotations;

namespace DeliverySystem.DevTeam.PL.ViewModels.Products
{
	public class CreateOrUodateProductViewModel
	{
		public int Id { get; set; }
        //[Required(ErrorMessage = "Please select a warehouse.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid warehouse.")]
        public int WarhouseId { get; set; }
		public string Name { get; set; } 
		public string Description { get; set; }
		[Required]
		public decimal? Price { get; set; }
        [Required]
        public int? QuantityAvailable { get; set; }
		public int MerchantId { get; set; }

		public List<Warhouse>? Warhouses { get; set; }
	}
}
