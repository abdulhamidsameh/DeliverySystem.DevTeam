using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.DevTeam.PL.Controllers
{
    public class WarehouseStaffController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public WarehouseStaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var orders = _unitOfWork.Repository<Order>().GetAll();
            return View(orders);
        }

        public IActionResult GetOrderDetails(int id)
        {
            var order = _unitOfWork.Repository<Order>().GetById(id);
            if(order is null) 
                return NotFound();
            return View(order);
        }
        [HttpPost]
        public IActionResult ConfirmOrder(int id)
        {
            var order = _unitOfWork.Repository<Order>().GetById(id);
            if (order is null)
                return NotFound();
            order.OrderStatus = OrderStatus.Processing;
            _unitOfWork.Repository<Order>().Update(order);
            _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }
    }
}
