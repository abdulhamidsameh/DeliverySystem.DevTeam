using System.ComponentModel.DataAnnotations;

namespace DeliverySystem.DevTeam.PL.ViewModels.Users
{
    public class UserFormViewModel
    {
        public string? Id { get; set; }
        [MaxLength(100, ErrorMessage = Errors.MaxLength)]
        [Display(Name ="Full Name")]
        public string FullName { get; set; } = null!;
        [MaxLength(20,ErrorMessage =Errors.MaxLength)]
        [Display(Name ="User Name")]
        public string UserName { get; set; } = null!;
        [MaxLength(200, ErrorMessage = Errors.MaxLength)]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [StringLength(100, ErrorMessage = Errors.MaxMinLength, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = Errors.ConfirmPasswordNotMatch)]
        public string ConfirmPassword { get; set; } = null!;
        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; }= new List<string>();
        public IEnumerable<SelectListItem>? Roles { get; set; }

    }
}
