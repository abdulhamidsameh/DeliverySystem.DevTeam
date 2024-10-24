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
}
