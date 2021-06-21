

namespace Git.Data
{
  public  class DataConstants
    {
        public const int UserMaxLength = 20;

        public const int UserMinLength = 5;

        public const int UserPasswordMinLength = 6;

        public const int RepositoryMinLength = 3;
        public const int RepositoryMaxLength = 10;

        public const string UserEmailValidatingRegex = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public const string RepositoryPublicType = "Public";
        public const string RepositoryPrivateType = "Private";


        public const int CommitDescriptionMinLength = 5;
    }
}
