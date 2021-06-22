using BattleCards.Data;
using BattleCards.Models;
using BattleCards.Services;
using BattleCards.ViewModels;
using MyWebServer.Controllers;
using MyWebServer.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
   public class CardsController:Controller
    {
        private readonly ApplicationDbContext data;
        private readonly IValidator validator;

        public CardsController(ApplicationDbContext dbContext, IValidator validator)
        {
            this.data = dbContext;
            this.validator = validator;
        }

        [Authorize]
        public ActionResult All()
        {
          

            var cards = data.Cards
                
                .Select(x => new CardAllViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    ImageUrl=x.ImageUrl,
                    Keyword=x.Keyword,
                    Description=x.Description,
                    Attack=x.Attack,
                    Health=x.Health

                })
                .ToList();

           return this.View(cards);
        }

        [Authorize]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Add(CardAddViewModel model)
        {
            var errors = validator.ValidateCards(model);

            if (errors.Count > 0)
            {
                return Error(errors);
            }

            var card = new Card
            {
                Name = model.Name,
                Description = model.Description,
                ImageUrl = model.Image,
                Attack = model.Attack,
                Health = model.Health,
                Keyword = model.Keyword
            };

            data.Cards.Add(card);
            data.SaveChanges();

            return Redirect("/Cards/All");
        }

        [Authorize]
        public ActionResult AddToCollection(int cardId)
        {
            ;

            int? cardID=data.Cards.Where(x => x.Id==cardId)
                .Select(x=>x.Id)
                .FirstOrDefault();

            if (!cardID.HasValue)
            {
                return BadRequest();
            }

            if (!data.UserCards.Any(x=>x.UserId==this.User.Id && x.CardId==cardID.Value))
            {

                var userCard = new UserCard
                {
                    CardId = cardID.Value,
                    UserId = this.User.Id
                };

                data.UserCards.Add(userCard);

                data.SaveChanges();

            }


        

            return Redirect("/Cards/All");

        }

        [Authorize]
        public ActionResult Collection()
        {
            var userCards = data.UserCards

                .Where(x=>x.UserId==this.User.Id)
                .Select(x=>x.Card)
                .Select(x => new CardAllViewModel
            {
                Id = x.Id,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Keyword = x.Keyword,
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health

            })
                .ToList();

            return this.View(userCards);

        }

        [Authorize]
        public ActionResult RemoveFromCollection(int cardId)
        {

            ;
            var card = data.Cards.Where(x => x.Id == cardId)
              
              .FirstOrDefault();

            if (card == null)
            {
                return BadRequest();
            }

            var userCard = this.data.UserCards.Where(x => x.CardId == card.Id && x.UserId == this.User.Id).FirstOrDefault();



            if (userCard==null)
            {
                return BadRequest();
            }

            data.UserCards.Remove(userCard);

            data.SaveChanges();


            return Redirect("/Cards/All");


        }


    }
}
