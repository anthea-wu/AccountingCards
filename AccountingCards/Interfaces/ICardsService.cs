using System.Collections.Generic;
using AccountingCards.Models;

namespace AccountingCards.Interfaces
{
    public interface ICardsService
    {
        void CreateDefaultCard(List<Card> cardList);
    }
}