using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data.Models
{
  public  class DataConstants
    {
        public const int IdMaxLength = 40;
        public const int UserMaxLength = 20;
        public const int UserMinLength = 4;
        public const int UserPasswordMinLength = 5;

        public const int CarYearMinValue = 1970;
        public const int CarYearMaxValue = 2021;


        public const string PlateNumberRegex = @"^[A-Z]{2}\d{4}[A-Z]{2}$";
        public const int PlateNumberMaxLength = 8;

        public const string UserEmailValidatingRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const string UserClientType = "Client";
        public const string UserMechanicType = "Mechanic";


        public const int IssueDescriptionMinLength = 5;
    }
}
