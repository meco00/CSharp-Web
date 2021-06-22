using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Models
{
   public class DataConstants
    {
        public const int IdMaxLength = 40;

        public const int UserMaxLength = 20;

        public const int MinLength = 5;

        public const int UserPasswordMinLength = 6;

       
        public const int CardNameMaxLength = 15;
        public const int CardStatsMinValue = 0;
        public const int CardDescriptionMaxLength = 200;

        public const string UserEmailValidatingRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const string RepositoryPublicType = "Public";
        public const string RepositoryPrivateType = "Private";


        public const int CommitDescriptionMinLength = 5;
    }
}
