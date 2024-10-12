

using AutoMapper;
using DeliverySystem.DevTeam.DAL.Models;
using DeliverySystem.DevTeam.PL.ViewModels.Merchant;
using DeliverySystem.DevTeam.PL.ViewModels.Products;

namespace DeliverySystem.DevTeam.PL.Helpers
{
    public class MappingProfile :Profile
    {


        public MappingProfile()
        {
            // Product
            CreateMap<Product, CreateOrUodateProductViewModel>().ReverseMap();
            CreateMap<Merchant, CreateOrUpdateMerchantViewModel>().ReverseMap();

        }
    }
}
