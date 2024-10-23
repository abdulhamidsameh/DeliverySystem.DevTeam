namespace DeliverySystem.DevTeam.PL.Controllers
{
	[Authorize(Roles = AppRoles.Merchant)]
	public class ProductsController : Controller
	{

		public ProductsController(IMapper mapper, IUnitOfWork unitOf,
			ApplicationDbContext context,
			UserManager<ApplicationUser> userManager)
		{

			_Mapper = mapper;
			_UnitOf = unitOf;
			_Context = context;
			_UserManager = userManager;
		}


		public IMapper _Mapper { get; }
		public IUnitOfWork _UnitOf { get; }
		public ApplicationDbContext _Context { get; }
		public UserManager<ApplicationUser> _UserManager { get; }

		public IActionResult Index()
		{
			var Products = _UnitOf.Repository<Product>().GetAll();

			return View(Products);
		}


		#region Add Product
		[HttpGet]
		[AjaxOnly]

		public IActionResult Create()
		{
			var Warhouse = _UnitOf.Repository<Warhouse>().GetAll();
			var Result = new CreateOrUodateProductViewModel()
			{

				Warhouses = Warhouse.ToList(),
			};
			return PartialView("_Form", Result);
		}
		[HttpPost]


		public async Task<IActionResult> Create(CreateOrUodateProductViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _UserManager.GetUserAsync(User);
				if (user != null)
				{
					var email = await _UserManager.GetEmailAsync(user);
					var product = _Mapper.Map<Product>(model);
					var spec = new BaseSpacefications<Merchant>(c => c.Email == email);
					var Merchant = _UnitOf.Repository<Merchant>().GetAllWithSpec(spec).FirstOrDefault();
					product.MerchantId = Merchant.Id;
					_UnitOf.Repository<Product>().Add(product);
					_UnitOf.Complete();
					return PartialView("_ProductRow", product);
				}



			}

			return View("_Form", model);




		}
		#endregion


		#region Edit

		[HttpGet]
		[AjaxOnly]

		public IActionResult Edit(int id)
		{
			var Product = _UnitOf.Repository<Product>().GetById(id);
			var Warhouse = _UnitOf.Repository<Warhouse>().GetAll();


			if (Product != null)
			{
				var Result = new CreateOrUodateProductViewModel()
				{
					Description = Product.Description,
					Id = Product.Id,
					Name = Product.Name,
					Price = Product.Price,
					QuantityAvailable = Product.QuantityAvailable,
					Warhouses = Warhouse.ToList(),
					WarhouseId = Product.WarhouseId


				};

				return PartialView("_Form", Result);
			}


			return NotFound();

		}

		[HttpPost]
		public IActionResult Edit(CreateOrUodateProductViewModel model)
		{
			var Product = _UnitOf.Repository<Product>().GetById(model.Id);

			if (Product != null)
			{
				Product.Price = model.Price;
				Product.Name = model.Name;
				Product.QuantityAvailable = model.QuantityAvailable;
				Product.Description = model.Description;
				Product.LastUpdatedOn = DateTime.Now;
				Product.WarhouseId = model.WarhouseId;
				_UnitOf.Complete();

				//TempData["message"] = "Saved SuccessFully";

				return PartialView("_ProductRow", Product);

			}


			return NotFound();

		}
		#endregion


		#region Toggle Status 


		public IActionResult ToggleStatus(int id)
		{


			var product = _UnitOf.Repository<Product>().GetById(id);

			if (product == null) { return NotFound(); };

			product.IsDeleted = !product.IsDeleted;
			product.LastUpdatedOn = DateTime.Now;
			_UnitOf.Complete();


			return Ok(product.LastUpdatedOn.ToString());
		}


		#endregion



		public IActionResult Productdetails(int id)
		{
			var spec = new BaseSpacefications<Warhouse>(W => W.Id == id);
			spec.Includes.Add(W => W.Products);

			ViewBag.ProductDetails = id;
			var Warhouse = _UnitOf.Repository<Warhouse>().GetAllWithSpec(spec).ToList();
			return View(Warhouse);
		}
	}

}
