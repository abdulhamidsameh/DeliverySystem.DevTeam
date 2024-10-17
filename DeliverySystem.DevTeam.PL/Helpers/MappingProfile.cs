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

            // Users
            CreateMap<ApplicationUser, UserViewModel>().ReverseMap();
		}
    }
}
