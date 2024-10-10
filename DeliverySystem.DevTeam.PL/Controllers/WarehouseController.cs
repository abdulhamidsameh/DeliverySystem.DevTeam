using DeliverySystem.DevTeam.BLL.ViewModels.Warehouse;
using DeliverySystem.DevTeam.DAL.Models;
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

        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(CreateOrUpdateWarehouseViewModel model)
        {
            if (ModelState.IsValid)
            {
                var warehouse = new Warehouse()
                {
                    Name = model.Name,
                    City = model.City,
                    Manager = model.Manager,
                };
                _dbContext.Warehouses.Add(warehouse);
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
            var warehouse = _dbContext.Warehouses.Find(id);

            if (warehouse != null)
            {
                var Result = new CreateOrUpdateWarehouseViewModel()
                {
                    Name = warehouse.Name,
                    City = warehouse.City,
                    Manager = warehouse.Manager,

                };
                return View("Form", Result);
            }


            return NotFound();

        }

        [HttpPost]
        public IActionResult Edit(CreateOrUpdateWarehouseViewModel model)
        {
            var warehouse = _dbContext.Warehouses.Find(model.Id);

            if (warehouse != null)
            {
                warehouse.Name = model.Name;
                warehouse.City = model.City;
                warehouse.Manager = model.Manager;

                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }


            return NotFound();

        }


        public IActionResult Delete(int id)
        {
            var warehouse = _dbContext.Warehouses.Find(id);
            if (warehouse is not null)
            {
                _dbContext.Warehouses.Remove(warehouse);
                _dbContext.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            return NotFound();

        }
    }
}
