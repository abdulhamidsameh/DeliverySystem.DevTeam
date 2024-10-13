using AutoMapper;
using DeliverySystem.DevTeam.BLL.Interfaces;
using DeliverySystem.DevTeam.DAL.Models;
using DeliverySystem.DevTeam.PL.Filters;
using DeliverySystem.DevTeam.PL.ViewModels.City;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeliverySystem.DevTeam.PL.Controllers
{
    public class CitysController : Controller
    {


        public CitysController(IUnitOfWork _unitOfWork, IMapper mapper)
        {
            _UnitOfWork = _unitOfWork;
            _Mapper = mapper;
        }

        public IUnitOfWork _UnitOfWork { get; }
        public IMapper _Mapper { get; }

        public IActionResult Index()
        {
            var sitys = _UnitOfWork.Repository<City>().GetAll();
            var result = _Mapper.Map<List<CityViewModal>>(sitys);
            return View(result);
        }

        [HttpGet]
        [AjaxOnly]
        public IActionResult Create()
        {

            return PartialView("_CityForm");

        }

        [HttpPost]
        [AjaxOnly]
        public IActionResult Create(CityViewModal city)
        {
            var result = _Mapper.Map<City>(city);

            var x = Enumerable.Empty<CityViewModal>();


            if (!ModelState.IsValid)
                return NotFound();
            _UnitOfWork.Repository<City>().Add(result);
            _UnitOfWork.Complete();
            return PartialView("_SityRow", city);

        }



        public IActionResult Edit(int id)
        {
            var city = _UnitOfWork.Repository<City>().GetById(id);

            if (city == null)
                return NotFound();

            var result = _Mapper.Map<CityViewModal>(city);


            return PartialView("_CityForm", result);

        }


        [HttpPost, AjaxOnly]
        public IActionResult Edit(CityViewModal city)
        {
            var result = _UnitOfWork.Repository<City>().GetById(city.Id);
            if (city == null)
                return NotFound();


            result.State = city.State;
            result.Country = city.Country;
            result.Name = city.Name;
            result.LastUpdatedOn = DateTime.Now;
            var result2 = _Mapper.Map<CityViewModal>(city);
            _UnitOfWork.Complete();
            return PartialView("_SityRow", result2);

        }


        public IActionResult ToggleStatus(int id)
        {

            var result = _UnitOfWork.Repository<City>().GetById(id);
            ;
            if (result == null) { return NotFound(); };
            result.IsDeleted = !result.IsDeleted;
            result.LastUpdatedOn = DateTime.Now;
            _UnitOfWork.Complete();

            return Ok(result.LastUpdatedOn.ToString());
        }
    }
}
