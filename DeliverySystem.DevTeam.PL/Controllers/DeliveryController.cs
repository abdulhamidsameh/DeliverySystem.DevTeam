using DeliverySystem.DevTeam.PL.ViewModels.Delivery;
using Microsoft.AspNetCore.Mvc;

namespace DeliverySystem.DevTeam.PL.Controllers
{
	[Authorize]
	public class DeliveryController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public DeliveryController( IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			var deliveries = _unitOfWork.Repository<Delivery>().GetAll();
			return View(deliveries);
		}

		[HttpGet]
		[AjaxOnly]
		public IActionResult Create()
		{
			return PartialView("_DeliveryForm");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CreateOrUpdateDeliveryViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var deliveries = new Delivery()
			{
				Name = model.Name,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				Address = model.Address
			};
			_unitOfWork.Repository<Delivery>().Add(deliveries);
			_unitOfWork.Complete();

			return PartialView("_DeliveryRow", deliveries);
		}


		[HttpGet]
		[AjaxOnly]
		public IActionResult Edit(int id)
		{
			var deliveries = _unitOfWork.Repository<Delivery>().GetById(id);

			if (deliveries is null)
				return NotFound();

			var viewModel = new CreateOrUpdateDeliveryViewModel()
			{
				Id = id,
				Name = deliveries.Name,
				Email = deliveries.Email,
				PhoneNumber = deliveries.PhoneNumber,
				Address = deliveries.Address

			};
			return PartialView("_DeliveryForm", viewModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(CreateOrUpdateDeliveryViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var deliveries = _unitOfWork.Repository<Delivery>().GetById(model.Id);

			if (deliveries is not null)
			{
				deliveries.Name = model.Name;
				deliveries.Email = model.Email;
				deliveries.PhoneNumber = model.PhoneNumber;
				deliveries.Address = model.Address;
				deliveries.LastUpdatedOn = DateTime.Now;

				_unitOfWork.Complete();

				return PartialView("_DeliveryRow", deliveries);
			}
			return NotFound();

		}

		[HttpPost]
		public IActionResult ToggleStatus(int id)
		{
			var deliveries = _unitOfWork.Repository<Delivery>().GetById(id);
			if (deliveries is null)
				return NotFound();
			deliveries.IsDeleted = !deliveries.IsDeleted;
			deliveries.LastUpdatedOn = DateTime.Now;
			_unitOfWork.Complete();
			return Ok(deliveries.LastUpdatedOn.ToString());


		}
	}
}
