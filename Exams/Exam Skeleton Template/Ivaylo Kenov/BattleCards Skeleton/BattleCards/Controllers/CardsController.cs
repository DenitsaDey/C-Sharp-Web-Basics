using BattleCards.Services;
using BattleCards.ViewModels.Card;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly IValidator validator;
        private readonly ICardsService cardsService;

        public CardsController(IValidator validator,
            ICardsService cardsService)
        {
            this.validator = validator;
            this.cardsService = cardsService;
        }

        [Authorize]
        public HttpResponse Add() => this.View();
        

        [HttpPost]
        [Authorize]
        public HttpResponse Add(RegisterCardInputModel input)
        {
            var modelErrors = this.validator.ValidateCard(input);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            var userId = this.User.Id;
            this.cardsService.Create(input, userId);
            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse All()
        {
            var cards = this.cardsService.GetAll();
            return this.View(cards);
        }

        [Authorize]
        public HttpResponse Collection()
        {
            var userId = this.User.Id;
            var myCollection = this.cardsService.UserCollection(userId);
            return this.View(myCollection);
        }

        [Authorize]
        public HttpResponse AddToCollection(int cardId)
        {
            var userId = this.User.Id;
            this.cardsService.AddCardToCollection(userId, cardId);
            return this.Redirect("/Cards/All");
        }

        [Authorize]
        public HttpResponse RemoveFromCollection(int cardId)
        { 
            var userId = this.User.Id;
            this.cardsService.RemoveCardFromCollection(userId, cardId);
            return this.Redirect("/Cards/Collection");
        }
    }
}
