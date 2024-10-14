

using AutoMapper;
using DeliverySystem.DevTeam.DAL.Models;
using DeliverySystem.DevTeam.PL.ViewModels.City;
using DeliverySystem.DevTeam.PL.ViewModels.Merchant;
using DeliverySystem.DevTeam.PL.ViewModels.Products;
using DeliverySystem.DevTeam.PL.ViewModels.Roles;
using DeliverySystem.DevTeam.PL.ViewModels.Warehouse;

namespace DeliverySystem.DevTeam.PL.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, CreateOrUodateProductViewModel>().ReverseMap();
            CreateMap<Merchant, CreateOrUpdateMerchantViewModel>().ReverseMap();
            CreateMap<Warhouse, CreateOrUpdateWarehouseViewModel>().ReverseMap();





            // City
            CreateMap<City,CityViewModal>().ReverseMap();


            // Roles
            CreateMap<ApplicationRole, CreateRoleViewModel>().ReverseMap();
            CreateMap<ApplicationRole, RoleToUpdateOrReturnViewModel>().ReverseMap();

		}
    }
}
