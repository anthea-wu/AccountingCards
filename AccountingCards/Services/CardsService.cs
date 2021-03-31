using System.Collections.Generic;
using AccountingCards.Interfaces;
using AccountingCards.Models;

namespace AccountingCards.Services
{
    public class CardsService : ICardsService
    {
        public void CreateDefaultCard(List<Card> cardList)
        {
            if (cardList.Count == 0)
            {
                cardList.Add( new Card() {Name = "Undefined", Order = 1} );    
            }
        }
    }
}