
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;



namespace DeliverySystem.DevTeam.PL.Controllers
{
	public static class BitmapExtention
	{
		public static byte[] ConvertBitmapToByteArray(this Bitmap bitmap)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				bitmap.Save(ms, ImageFormat.Png);
				return ms.ToArray();
			}
		}
	}

	[Authorize]
	public class WarehouseStaffController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IConfiguration _configuration;

		public WarehouseStaffController(IUnitOfWork unitOfWork,
			IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var spec = new BaseSpacefications<Order>(O => O.OrderStatus == OrderStatus.Processing);
			spec.Includes.Add(O => O.Merchant);
			spec.Includes.Add(O => O.Warehouse);

			var orders = _unitOfWork.Repository<Order>().GetAllWithSpec(spec);
			if (orders is null)
				return NotFound();


			return View(orders);
		}
		[HttpGet]
		public IActionResult GetOrderDetails(int id)
		{
			var spec = new BaseSpacefications<Order>(O => (O.Id == id && O.OrderStatus == OrderStatus.Processing));
			spec.Includes.Add(O => O.Merchant);
			spec.Includes.Add(O => O.Warehouse);
			spec.Includes.Add(o => o.OrderProducts);

			var order = _unitOfWork.Repository<Order>().GetWithSpec(spec);
			var qrCodeImage = GenerateQRCode(order);
			ViewBag.QRCodeImage = qrCodeImage;
			if (order is null)
				return NotFound();
			return View(order);
		}
		[HttpPost]
		public IActionResult ConfirmOrder(int id)
		{
			var order = _unitOfWork.Repository<Order>().GetById(id);

			if (order is null)
				return NotFound();
			order.OrderStatus = OrderStatus.Shipped;
			_unitOfWork.Repository<Order>().Update(order);
			_unitOfWork.Complete();
			return RedirectToAction(nameof(Index));
		}


		private string GenerateQRCode(Order order)
		{
			string qrText = $"{_configuration["BaseUrl"]}/WarehouseStaff/GetOrderDetails/{order.Id}";



			using (QRCodeGenerator qrGenerator = new())
			using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q))


			using (QRCode qrCode = new QRCode(qrCodeData))
			{
				Bitmap qrCodeImage = qrCode.GetGraphic(20);

				byte[] BitmapArray = qrCodeImage.ConvertBitmapToByteArray();



				string Url = Convert.ToBase64String(BitmapArray);
				return $"data:image/png;base64,{Url}";


			}



		}
	}

}





