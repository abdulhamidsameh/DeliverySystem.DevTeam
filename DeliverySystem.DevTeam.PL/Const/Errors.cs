namespace DeliverySystem.DevTeam.PL.Const
{
    public static class Errors
    {
        public const string MaxLength = "Length cannot be more than {1} characters";
        public const string MaxMinLength = "The {0} must be at least {2} and at max {1} characters long.";
        public const string Duplicated = "{0} with the same name is already exists!";
        public const string InvalidRange = "{0} should be between {1} and {2}";
        public const string ConfirmPasswordNotMatch = "The password and confirmation password do not match.";
    }
}
