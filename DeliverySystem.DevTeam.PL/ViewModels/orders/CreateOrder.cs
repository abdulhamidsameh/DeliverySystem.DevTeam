namespace DeliverySystem.DevTeam.PL.ViewModels.orders
{
    public class CreateOrderViewModel
    {
        [Required]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string PhoneNumber { get; set; }
        [Required]
        public bool IsCashOnDelivery { get; set; }

        public string Address { get; set; }
        [Required]
        public int WarehouseId { get; set; }
        public int WarehouseIId { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int MerchantId { get; set; }
        [Required]
        public List<OrderProduct>? Products { get; set; } = new List<OrderProduct>();
        public IEnumerable<Product>? ProductsList { get; set; }
        public decimal SubTotal { get; set; }
        public decimal WarehouseCommation { get; set; }
        public string MerchantName { get; set; }
    }
    public class CreateOrderProduct
    {
        public int ProductId { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
}
