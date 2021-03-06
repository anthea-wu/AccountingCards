using System.Collections.Generic;
using AccountingCards.Models;

namespace AccountingCards.Interfaces
{
    public interface ICardsService
    {
        public void CreateDefaultCard(List<Card> cardList);
    }
}