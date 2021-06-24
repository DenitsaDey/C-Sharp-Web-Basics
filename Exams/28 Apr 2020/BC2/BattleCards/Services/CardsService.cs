using BattleCards.Data;
using BattleCards.Models;
using BattleCards.ViewModels.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;
        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(CreateCardInputModel input, string userId)
        {
            var newCard = new Card
            {
                Name = input.Name,
                ImageUrl = input.ImageUrl,
                Keyword = input.Keyword,
                Attack = input.Attack,
                Health = input.Health,
                Description = input.Description
            };

            this.db.Cards.Add(newCard);
            this.db.SaveChanges();
            var cardId = newCard.Id;
            if (!this.db.UserCards.Any(uc => uc.UserId == userId && uc.CardId == cardId))
            {
                this.db.UserCards.Add(new UserCard
                {
                    UserId = userId,
                    CardId = cardId
                });
                this.db.SaveChanges();
            }

        }

        public IEnumerable<CardsAllViewModel> GetAll ()
        {
            var allCards = this.db.Cards.Select(c => new CardsAllViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                Keyword = c.Keyword,
                Attack = c.Attack,
                Health = c.Health
            })
                .ToList();

            return allCards;
        }

        public IEnumerable<CardsAllViewModel> UserCollection(string userId)
        {
            var userCollection = this.db.UserCards
                .Where(uc => uc.UserId == userId)
                .Select(uc => new CardsAllViewModel
                {
                    Id = uc.CardId,
                    Name = uc.Card.Name,
                    ImageUrl = uc.Card.ImageUrl,
                    Description = uc.Card.Description,
                    Keyword = uc.Card.Keyword,
                    Attack = uc.Card.Attack,
                    Health = uc.Card.Health
                })
                .ToList();

            return userCollection;
        }

        public void AddCardToCollection(string userId, int cardId)
        {
            if(this.db.UserCards.Any(uc=>uc.UserId == userId && uc.CardId == cardId))
            {
                return;
            }
            this.db.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId
            });
            this.db.SaveChanges();
        }
        public void RemoveCardFromCollection(string userId, int cardId)
        {
            var cardToRemove = this.db.UserCards
                .Where(uc => uc.UserId == userId && uc.CardId == cardId)
                .FirstOrDefault();
            if(cardToRemove == null)
            {
                return;
            }
            this.db.UserCards.Remove(cardToRemove);
            this.db.SaveChanges();
        }
    }
}
