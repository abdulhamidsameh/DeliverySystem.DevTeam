﻿namespace DeliverySystem.DevTeam.DAL.Models
{
	public class Product : BaseEntity
	{

		public string Name { get; set; }
		public string Description { get; set; }
		public decimal? Price { get; set; }
		public int? QuantityAvailable { get; set; }
		public int WarhouseId { get; set; }
		public Warhouse Warhouse { get; set; }

        public int MerchantId { get; set; }

        public Merchant Merchant { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
