﻿namespace DeliverySystem.DevTeam.PL.Controllers
{
    [Authorize]
    public class WarehouseStaffController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseStaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
    }
}