using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliverySystem.DevTeam.DAL.Models
{
    public enum OrderStatus
    {
        Pending = 1,         // قيد الانتظار
        Processing = 2,      // قيد المعالجة
        Shipped = 3,         // تم الشحن
        Delivered = 4,       // تم التسليم
        Canceled = 5         // تم الإلغاء
    }

    public class Order : BaseEntity
    {   

        public int MerchantId { get; set; }
        public Merchant Merchant { get; set; }
        public int WarehouseId { get; set; }
        public Warhouse Warehouse { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string PhoneNumber { get; set; }
        public string MerchantName { get; set; }
        public string Address { get; set; }
        public bool IsCashOnDelivery { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
