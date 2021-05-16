using System;
using System.Collections.Generic;
using System.Linq;
using AccountingCards.Controllers;
using AccountingCards.Models;

namespace AccountingCards.Services
{
    public class CardsService
    {
        public void CreateDefaultCard(List<Card> cardList)
        {
            if (cardList.Count == 0)
            {
                cardList.Add( new Card() {Name = "Undefined", Order = 0} );    
            }
        }

        public void CreateDefaultDetails(AccountingViewModel accounting)
        {
            if (accounting.Details.Count == 0)
            {
                accounting.Details.Add(new Detail()
                {
                    Card = accounting.Cards[0],
                    Date = DateTime.Now.ToString("yyyy MMMM dd"),
                    Info = "This is the default card and details.",
                    Order = 0,
                    Price = 0
                });
            }
        }

        public AccountingViewModel GetCurrentAccountingCard(AccountingViewModel accounting, string name)
        {
            var currentCard = GetNotNullCurrentCard(accounting.Cards, name) ?? GetDefaultErrorCard();
            var currentDetails = accounting.Details.Where(x => string.Equals(x.Card.Name, name, StringComparison.CurrentCultureIgnoreCase)).ToList();
            return new AccountingViewModel()
            {
                Cards = new List<Card>() {currentCard},
                Details = currentDetails,
            };
        }

        private static Card GetDefaultErrorCard()
        {
            return new Card() {Name = "Unfounded", Order = -1};
        }

        private static Card GetNotNullCurrentCard(List<Card> cards, string name)
        {
            return cards.Find(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public void CreateDefaultCardAndDetail(AccountingViewModel accounting)
        {
            if (accounting.Cards.Count == 0)
            {
                accounting.Cards.Add( new Card() {Name = "Undefined", Order = 0} );
                accounting.Details.Add(new Detail()
                {
                    Card = accounting.Cards[0],
                    Date = DateTime.Now.ToString("yyyy MMMM dd"),
                    Info = "This is the default card and details.",
                    Order = 0,
                    Price = 0
                });
            }
        }
    }
}