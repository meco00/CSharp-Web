using BattleCards.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Services
{
   public interface IValidator
    {
         ICollection<string> ValidateUsers(UserRegisterViewModel model);

         ICollection<string> ValidateCards(CardAddViewModel model);


    }
}
