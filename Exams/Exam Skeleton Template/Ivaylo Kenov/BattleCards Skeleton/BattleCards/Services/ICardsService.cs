using BattleCards.ViewModels.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        void Create(RegisterCardInputModel input, string userId);
        IEnumerable<CardsAllViewModel> GetAll();

        IEnumerable<CardsAllViewModel> UserCollection(string userId);

        void AddCardToCollection(string userId, int cardId);

        void RemoveCardFromCollection(string userId, int cardId);
    }
}
