namespace DeliverySystem.DevTeam.PL.ViewModels.Users
{
    public class UserFormViewModel
    {
        public string? Id { get; set; }

        [Display(Name = "Full Name")]
        [MaxLength(100, ErrorMessage = Errors.MaxLength)]
        [RegularExpression(RegexPatterns.NumbersAndChrOnly_ArEng,
            ErrorMessage = Errors.OnlyNumbersAndLetters)]
        public string FullName { get; set; } = null!;

        [Display(Name = "User Name")]
        [MaxLength(20, ErrorMessage = Errors.MaxLength),
        RegularExpression(RegexPatterns.Username,
            ErrorMessage = Errors.InvalidUsername)]
        [Remote(action: "AllowUserName", controller: null!,
            AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
        public string UserName { get; set; } = null!;

        [MaxLength(200, ErrorMessage = Errors.MaxLength)]
        [EmailAddress]
        [Remote(action: "AllowEmail", controller: null!, AdditionalFields = "Id", ErrorMessage = Errors.Duplicated)]
        public string Email { get; set; } = null!;

        [RegularExpression(RegexPatterns.Password,
            ErrorMessage = Errors.WeakPassword)]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = Errors.MaxMinLength, MinimumLength = 8)]
        //[RequiredIf(expression: "Id == null", ErrorMessage = Errors.RequiredField)]
        public string? Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare(nameof(Password), ErrorMessage = Errors.ConfirmPasswordNotMatch)]
        //[RequiredIf(expression: "Id == null", ErrorMessage = Errors.RequiredField)]
        public string? ConfirmPassword { get; set; } = null!;

        [Display(Name = "Roles")]
        public IList<string> SelectedRoles { get; set; } = new List<string>();

        public IEnumerable<SelectListItem>? Roles { get; set; }

    }
}