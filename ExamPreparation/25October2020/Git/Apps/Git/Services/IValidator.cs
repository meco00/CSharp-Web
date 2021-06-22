using Git.ViewModels;
using System;
using System.Collections.Generic;


namespace Git.Services
{
   public interface IValidator
    {
        public ICollection<string> ValidateUsers(UserRegisterViewModel model);

        public ICollection<string> ValidateRepository(RepositoryCreateViewModel model);
    }
}
