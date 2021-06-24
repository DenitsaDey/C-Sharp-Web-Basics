using BattleCards.ViewModels.Card;
using System;
using System.Collections.Generic;
using System.Text;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void Create(CreateCardInputModel input, string userId);
        IEnumerable<CardsAllViewModel> GetAll();

        IEnumerable<CardsAllViewModel> UserCollection(string userId);

        void AddCardToCollection(string userId, int cardId);

        void RemoveCardFromCollection(string userId, int cardId);
    }
}
