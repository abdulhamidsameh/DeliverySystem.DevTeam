namespace DeliverySystem.DevTeam.PL.Controllers
{
	[Authorize]
	public class MerchantsController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public MerchantsController(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public IActionResult Index()
		{
			var merchants = _unitOfWork.Repository<Merchant>().GetAll();
			return View(merchants);
		}

		[HttpGet]
		[AjaxOnly]
		public IActionResult Create()
		{
			return PartialView("_MerchantForm");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(CreateOrUpdateMerchantViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var merchant = new Merchant()
			{
				Name = model.Name,
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				Address = model.Address
			};
			_unitOfWork.Repository<Merchant>().Add(merchant);
			_unitOfWork.Complete();

			return PartialView("_MerchantRow",merchant);
		}


		[HttpGet]
		[AjaxOnly]
		public IActionResult Edit(int id)
		{
			var merchant = _unitOfWork.Repository<Merchant>().GetById(id);

			if (merchant is null)
				return NotFound();

			var viewModel = new CreateOrUpdateMerchantViewModel()
			{
				Id = id,
				Name = merchant.Name,
				Email = merchant.Email,
				PhoneNumber = merchant.PhoneNumber,
				Address = merchant.Address

			};
			return PartialView("_MerchantForm", viewModel);
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(CreateOrUpdateMerchantViewModel model)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			var merchant = _unitOfWork.Repository<Merchant>().GetById(model.Id);

			if (merchant is not null)
			{
				merchant.Name = model.Name;
				merchant.Email = model.Email;
				merchant.PhoneNumber = model.PhoneNumber;
				merchant.Address = model.Address;
				merchant.LastUpdatedOn = DateTime.Now;

				_unitOfWork.Complete();


				return PartialView("_MerchantRow",merchant);
			}
			return NotFound();

		}

		[HttpPost]
		public IActionResult ToggleStatus(int id)
		{
			var merchant = _unitOfWork.Repository<Merchant>().GetById(id);
			if (merchant is null)
				return NotFound();
			merchant.IsDeleted = !merchant.IsDeleted;
			merchant.LastUpdatedOn = DateTime.Now;
			_unitOfWork.Complete();
			return Ok(merchant.LastUpdatedOn.ToString());


		}
	}
}
