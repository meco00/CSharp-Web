

namespace CarShop.Constants
{
   public  class DataConstants
    {
        public const int UserUsernameMaxLength = 20;
        public const int UserUsernameMinLength = 4;
        public const int UserPasswordMaxLength = 20;
        public const int UserPasswordMinLength = 5;
        public const string UserTypeClient = "Client";
        public const string UserTypeMechanic = "Mechanic";


        public const int CarModelMinLength = 5;
        public const int CarModelMaxLength = 20;
        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2100;

        public const int IssueDescriptionMinLength=5;

        public const string CarPlateNumberRegex= @"^[A-Z]{2}[0-4]{4}[A-Z]{2}$";

        public const string UserEmailRegexPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        
    }
}
