using BattleCards.Services;
using BattleCards.ViewModels.Card;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ICardsService cardsService;
        public CardsController(ICardsService cardsService)
        {
            this.cardsService = cardsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
        
        [HttpPost]
        public HttpResponse Add(CreateCardInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(input.Name) ||
                input.Name.Length < 5 ||
                input.Name.Length > 15)
            {
                return this.Error("Name should be be between 5 and 15 characters long");
            }

            if (string.IsNullOrWhiteSpace(input.ImageUrl))
            {
                return this.Error("Image url is required.");
            }

            if (string.IsNullOrWhiteSpace(input.Keyword))
            {
                return this.Error("Keyword is required.");
            }

            if (input.Attack<0)
            {
                return this.Error("Attack is required and cannot be of negative value.");
            }

            if (input.Health < 0)
            {
                return this.Error("Health is required and cannot be of negative value.");
            }

            if (string.IsNullOrWhiteSpace(input.Description) ||
                input.Description.Length > 200)
            {
                return this.Error("Description is required and should be above 200 characters long");
            }

            var userId = this.GetUserId();
            this.cardsService.Create(input, userId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            //string userId = this.GetUserId();
            var cards = this.cardsService.GetAll();
            return this.View(cards);
        }

        public HttpResponse Collection()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            var myCollection = this.cardsService.UserCollection(userId);
            return this.View(myCollection);
        }

        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.cardsService.AddCardToCollection(userId, cardId);
            return this.Redirect("/Cards/All");
        }

        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var userId = this.GetUserId();
            this.cardsService.RemoveCardFromCollection(userId, cardId);
            return this.Redirect("/Cards/Collection");
        }
    }
}
