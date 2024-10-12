using DeliverySystem.DevTeam.DAL.Models;
using DeliverySystem.DevTeam.PL.Filters;
using DeliverySystem.DevTeam.PL.ViewModels.Merchant;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.DevTeam.PL.Controllers
{
	public class MerchantsController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public MerchantsController(ApplicationDbContext dbContext)
		{
			this._dbContext = dbContext;
		}
		public IActionResult Index()
		{
			var merchants = _dbContext.Merchants.AsNoTracking().ToList();
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
			_dbContext.Merchants.Add(merchant);
			_dbContext.SaveChanges();

			return PartialView("_MerchantRow",merchant);
		}


		[HttpGet]
		[AjaxOnly]
		public IActionResult Edit(int id)
		{
			var merchant = _dbContext.Merchants.Find(id);

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
			var merchant = _dbContext.Merchants.Find(model.Id);

			if (merchant is not null)
			{
				merchant.Name = model.Name;
				merchant.Email = model.Email;
				merchant.PhoneNumber = model.PhoneNumber;
				merchant.Address = model.Address;
				merchant.LastUpdatedOn = DateTime.Now;

				_dbContext.SaveChanges();


				return PartialView("_MerchantRow",merchant);
			}
			return NotFound();

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ToggleStatus(int id)
		{
			var merchant = _dbContext.Merchants.Find(id);
			if (merchant is null)
				return NotFound();
			merchant.IsDeleted = !merchant.IsDeleted;
			merchant.LastUpdatedOn = DateTime.Now;
			_dbContext.SaveChanges();
			return Ok(merchant.LastUpdatedOn.ToString());


		}
	}
}
