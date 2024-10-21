namespace DeliverySystem.DevTeam.PL.ViewModels.Users
{
	public class UserViewModel
	{
		public string Id { get; set; } = null!;
        [RegularExpression(RegexPatterns.NumbersAndChrOnly_ArEng,
    ErrorMessage = Errors.OnlyNumbersAndLetters)]
        public string FullName { get; set; } = null!;
        [RegularExpression(RegexPatterns.NumbersAndChrOnly_ArEng,
    ErrorMessage = Errors.OnlyNumbersAndLetters)]
        public string UserName { get; set; } = null!;
        [RegularExpression(RegexPatterns.NumbersAndChrOnly_ArEng,
    ErrorMessage = Errors.OnlyNumbersAndLetters)]
        public string Email { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
		public DateTime? LastUpdatedOn { get; set; } 
    }
}
