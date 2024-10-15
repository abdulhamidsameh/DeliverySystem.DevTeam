



using DeliverySystem.DevTeam.DAL.Models;

namespace DeliverySystem.DevTeam.PL.Controllers
{
    public class ProductsController : Controller
    {

        public ProductsController( IMapper mapper ,IUnitOfWork unitOf,ApplicationDbContext context)
        {
          
            _Mapper = mapper;
			_UnitOf = unitOf;
			_Context = context;
		}

      
        public IMapper _Mapper { get; }
		public IUnitOfWork _UnitOf { get; }
		public ApplicationDbContext _Context { get; }

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
        public IActionResult Create(CreateOrUodateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
            
                var product = _Mapper.Map<Product>(model);

				_UnitOf.Repository<Product>().Add(product);
				//TempData["message"] = "Saved SuccessFully";

				_UnitOf.Complete();
                return PartialView("_ProductRow", product);

            }
            else
            {
                return View("_Form", model);
            }



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
            //var Warhouse = _UnitOf.Repository<Warhouse>().GetById(id);
            var Warhouse = _Context.Warehouses.Where(c => c.Id == id).Include(x => x.Products).ToList();
			return View(Warhouse);
        }




	}

}
