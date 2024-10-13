using DeliverySystem.DevTeam.DAL.Models;
using DeliverySystem.DevTeam.PL.Filters;
using DeliverySystem.DevTeam.PL.ViewModels.Merchant;
using DeliverySystem.DevTeam.PL.ViewModels.Warehouse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.DevTeam.PL.Controllers
{
	public class WarehouseController : Controller
	{
		private readonly ApplicationDbContext _dbContext;

		public WarehouseController(ApplicationDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IActionResult Index()
		{
			var warehouse = _dbContext.Warehouses.AsNoTracking().ToList();
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
			_dbContext.Warehouses.Add(warehouse);
			_dbContext.SaveChanges();

			return PartialView("_WarehouseRow", warehouse);
		}


		[HttpGet]
		[AjaxOnly]
		public IActionResult Edit(int id)
		{
			var warehouse = _dbContext.Warehouses.Find(id);

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
			var warehouse = _dbContext.Warehouses.Find(model.Id);

			if (warehouse is not null)
			{
				warehouse.Name = model.Name;
				warehouse.City = model.City;
				
				warehouse.LastUpdatedOn = DateTime.Now;

				_dbContext.SaveChanges();


				return PartialView("_WarehouseRow", warehouse);
			}
			return NotFound();

		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ToggleStatus(int id)
		{
			var warehouse = _dbContext.Warehouses.Find(id);
			if (warehouse is null)
				return NotFound();
			warehouse.IsDeleted = !warehouse.IsDeleted;
			warehouse.LastUpdatedOn = DateTime.Now;
			_dbContext.SaveChanges();
			return Ok(warehouse.LastUpdatedOn.ToString());


		}
	}
}
