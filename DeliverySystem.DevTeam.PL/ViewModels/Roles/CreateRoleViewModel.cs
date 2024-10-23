namespace DeliverySystem.DevTeam.PL.ViewModels.Roles
{
    public class CreateRoleViewModel
    {
        public string? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
