using System;

namespace SharedTrip.Data
{
   public class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int DefaultMaxLength = 20;

        public const int UserMinUsername = 5;
        public const int UserMinPassword = 6;

        public const int TripSeatMinValue = 2;
        public const int TripSeatMaxValue = 6;
        public const int TripDescriptionMaxLength = 80;

        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    

    }
}
