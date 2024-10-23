namespace DeliverySystem.DevTeam.PL.Controllers
{
	public class WarehouseController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public WarehouseController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IActionResult Index()
		{
			var warehouse = _unitOfWork.Repository<Warhouse>().GetAll();
			return View(warehouse);
		}

		[HttpGet]
		[AjaxOnly]
		public IActionResult Create()
		{
			return PartialView("_WarehouseForm");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CreateOrUpdateWarehouseViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var warehouse = new Warhouse()
			{
				Name = model.Name,
				City = model.City,
			};
			_unitOfWork.Repository<Warhouse>().Add(warehouse);
			_unitOfWork.Complete();

			return PartialView("_WarehouseRow", warehouse);
		}


		[HttpGet]
		[AjaxOnly]
		public IActionResult Edit(int id)
		{
			var warehouse = _unitOfWork.Repository<Warhouse>().GetById(id);

			if (warehouse is null)
				return NotFound();

			var viewModel = new CreateOrUpdateWarehouseViewModel()
			{
				Id = id,
				Name = warehouse.Name,
				City = warehouse.City,


			};
			return PartialView("_WarehouseForm", viewModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(CreateOrUpdateWarehouseViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var warehouse = _unitOfWork.Repository<Warhouse>().GetById(model.Id);

			if (warehouse is not null)
			{
				warehouse.Name = model.Name;
				warehouse.City = model.City;
				
				warehouse.LastUpdatedOn = DateTime.Now;

				_unitOfWork.Complete();


				return PartialView("_WarehouseRow", warehouse);
			}
			return NotFound();

		}

		[HttpPost]
		public IActionResult ToggleStatus(int id)
		{
			var warehouse = _unitOfWork.Repository<Warhouse>().GetById(id);
			if (warehouse is null)
				return NotFound();
			warehouse.IsDeleted = !warehouse.IsDeleted;
			warehouse.LastUpdatedOn = DateTime.Now;
			_unitOfWork.Complete();
			return Ok(warehouse.LastUpdatedOn.ToString());


		}
	}
}
