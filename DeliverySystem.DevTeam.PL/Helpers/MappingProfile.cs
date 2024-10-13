namespace DeliverySystem.DevTeam.PL.Helpers
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            // Product
            CreateMap<Product, CreateOrUodateProductViewModel>().ReverseMap();

            // Roles
            CreateMap<ApplicationRole, CreateRoleViewModel>().ReverseMap();
            CreateMap<ApplicationRole, RoleToUpdateOrReturnViewModel>().ReverseMap();

		}
    }
}
