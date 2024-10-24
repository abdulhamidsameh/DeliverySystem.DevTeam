namespace DeliverySystem.DevTeam.DAL.Models
{
	public class OrderProduct :BaseEntity
    {
        // معرّف فريد للسجل

        public int OrderId { get; set; } // معرّف الطلب
        public Order Order { get; set; } // علاقة مع كائن الطلب

        public int ProductId { get; set; } // معرّف المنتج
        public Product Product { get; set; } // علاقة مع كائن المنتج
        public decimal? Price { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
