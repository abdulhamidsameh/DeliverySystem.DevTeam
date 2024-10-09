

using DeliverySystem.DevTeam.DAL.Models;
using DeliverySystem.DevTeam.PL.ViewModels.Products;
using Microsoft.EntityFrameworkCore;


namespace DeliverySystem.DevTeam.PL.Controllers
{
    public class ProductsController : Controller
    {

        public ProductsController(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public ApplicationDbContext _DbContext { get; }

        public IActionResult Index()
        {
            var Products = _DbContext.Products.AsNoTracking().ToList();

            return View(Products);
        }


        #region Add Product
        public IActionResult Create()
        {

            return View("Form");

        }
        [HttpPost]
        public IActionResult Create(CreateOrUodateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product()
                {
                    Description = model.Description,
                    Price = model.Price,
                    Name = model.Name,
                    QuantityAvailable = model.QuantityAvailable
                };


                _DbContext.Products.Add(product);
                TempData["message"] = "Saved SuccessFully";

                _DbContext.SaveChanges();
            }
            else
            {
                return View("Form", model);
            }


            return RedirectToAction(nameof(Index));

        }
        #endregion


        #region Edit

        [HttpGet]
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

                return View("Form", Result);
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
				TempData["message"] = "Saved SuccessFully";

				return RedirectToAction(nameof(Index));
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
            product.LastUpdatedOn =DateTime.Now;
            _DbContext.SaveChanges();

            return Ok(product.LastUpdatedOn.ToString());
        }


        #endregion



    }

}
