using System;
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

        public AccountingViewModel GetCurrentAccountingCard(List<Card> cards, string name)
        {
            var currentCard = GetNotNullCurrentCard(cards, name) ?? GetDefaultErrorCard();
            return new AccountingViewModel() {Cards = new List<Card>() {currentCard}};
        }

        private static Card GetDefaultErrorCard()
        {
            return new Card() {Name = "Unfounded", Order = -1};
        }

        private static Card GetNotNullCurrentCard(List<Card> cards, string name)
        {
            return cards.Find(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}