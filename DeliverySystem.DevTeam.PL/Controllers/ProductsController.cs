



namespace DeliverySystem.DevTeam.PL.Controllers
{
    public class ProductsController : Controller
    {

        public ProductsController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _DbContext = dbContext;
            _Mapper = mapper;
        }

        public ApplicationDbContext _DbContext { get; }
        public IMapper _Mapper { get; }

        public IActionResult Index()
        {
            var Products = _DbContext.Products.AsNoTracking().ToList();

            return View(Products);
        }


        #region Add Product
        [HttpGet]
        [AjaxOnly]
        public IActionResult Create()
        {

            return PartialView("_Form");

        }
        [HttpPost]
        public IActionResult Create(CreateOrUodateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
            
                var product = _Mapper.Map<Product>(model);

                _DbContext.Products.Add(product);
                //TempData["message"] = "Saved SuccessFully";

                _DbContext.SaveChanges();
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
            var Product = _DbContext.Products.Find(id);

            if (Product != null)
            {
                var Result = new CreateOrUodateProductViewModel()
                {
                    Description = Product.Description,
                    Id = Product.Id,
                    Name = Product.Name,
                    Price = Product.Price,
                    QuantityAvailable = Product.QuantityAvailable

                };

                return PartialView("_Form", Result);
            }


            return NotFound(); 

        }

        [HttpPost]
        public IActionResult Edit(CreateOrUodateProductViewModel model)
        {
            var Product = _DbContext.Products.Find(model.Id);

            if (Product != null)
            {
                Product.Price = model.Price;
                Product.Name = model.Name;
                Product.QuantityAvailable = model.QuantityAvailable;
                Product.Description = model.Description;
                Product.LastUpdatedOn = DateTime.Now;
                _DbContext.SaveChanges();
                //TempData["message"] = "Saved SuccessFully";

                return PartialView("_ProductRow", Product);

            }


            return NotFound();

        }
        #endregion


        #region Toggle Status 


        public IActionResult ToggleStatus(int id)
        {


            var product = _DbContext.Products.Find(id);
            if (product == null) { return NotFound(); };

            product.IsDeleted = !product.IsDeleted;
            product.LastUpdatedOn = DateTime.Now;
            _DbContext.SaveChanges();

            return Ok(product.LastUpdatedOn.ToString());
        }


        #endregion





    }

}
