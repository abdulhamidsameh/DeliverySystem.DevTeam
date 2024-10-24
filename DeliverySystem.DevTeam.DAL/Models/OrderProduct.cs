namespace DeliverySystem.DevTeam.DAL.Models
{
	public class OrderProduct :BaseEntity
    {
       

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; } 
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
