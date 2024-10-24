namespace DeliverySystem.DevTeam.DAL.Models
{
	public class Order : BaseEntity
    {   

        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int WarehouseId { get; set; }
        public Warhouse Warehouse { get; set; }
        public DateTime OrderDate { get; set; }
        // SubTotal => Quantity * Price ===> - Merchant (منتجات بكميات معينه * سعر المنتج ) 
        // 
        // Total = SubTotal + Commition
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public bool IsCashOnDelivery { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
