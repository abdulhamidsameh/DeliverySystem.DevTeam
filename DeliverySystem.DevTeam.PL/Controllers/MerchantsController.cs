using DeliverySystem.DevTeam.BLL.ViewModels.Merchant;
using DeliverySystem.DevTeam.BLL.ViewModels.Products;
using DeliverySystem.DevTeam.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.DevTeam.PL.Controllers
{
	public class MerchantsController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public MerchantsController(ApplicationDbContext dbContext)
        {
			_dbContext = dbContext;
		}
        public IActionResult Index()
		{
			var merchants = _dbContext.Merchants.ToList();
			return View(merchants);
		}

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(CreatedOrUpdatedMerchantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var Merchant = new Merchant()
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Address = "address",
                    Password="password"
                };
                _dbContext.Merchants.Add(Merchant);
                _dbContext.SaveChanges();
            }
			else
			{
				return View("Form", model);
			}

			return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var merchant = _dbContext.Merchants.Find(id);

            if (merchant != null)
            {
                var Result = new CreatedOrUpdatedMerchantViewModel()
                {
                    Name = merchant.Name,
                    Id = merchant.Id,
                    Email = merchant.Email,
                    PhoneNumber = merchant.PhoneNumber,

                };
                return View("Form", Result);
            }


            return NotFound();

        }

        [HttpPost]
        public IActionResult Edit(CreatedOrUpdatedMerchantViewModel model)
        {
            var merchant = _dbContext.Merchants.Find(model.Id);

            if (merchant != null)
            {
                merchant.Name = model.Name;
                merchant.Email = model.Email;
                merchant.PhoneNumber = model.PhoneNumber;
               
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return NotFound();

        }



    }
}
