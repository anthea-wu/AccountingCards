using System.Collections.Generic;
using AccountingCards.Controllers;
using AccountingCards.Models;
using AccountingCards.Services;
using FluentAssertions;
using FluentAssertions.Primitives;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;

namespace UnitTest
{
    public class CardsServicesTest
    {
        private CardsService _cardsService;
        
        [SetUp]
        public void Setup()
        {
            _cardsService = Substitute.For<CardsService>();
        }

        [Test]
        public void When_Accounting_Cards_Empty_Should_Create_Default_Card()
        {
            var cards = GivenCardListWithoutCards();
            CreateDefaultCard(cards);

            CardsShouldEqualToDefaultCard(GivenDefaultCards(), cards);
        }

        [Test]
        public void When_Accounting_Cards_Not_Empty_Should_Not_Create_Default_Card()
        {
            var cards = GiveCardListWithCards();
            CreateDefaultCard(cards);

            CardsShouldNotEqualToDefaultCard(GivenDefaultCards(), cards);
        }

        [Test]
        public void When_Cards_Not_Exist_Should_Create_Error_Card()
        {
            var emptyCards = GivenCardListWithoutCards();
            var currentCard = _cardsService.GetCurrentAccountingCard(emptyCards, "Foods");

            ShouldGetErrorCard(currentCard.Cards);
        }

        [Test]
        public void When_Cards_Exist_Should_Get_Current_Card()
        {
            var cards = GivenAccountingViewModel("Foods");
            var currentCard = _cardsService.GetCurrentAccountingCard(cards.Cards, "Foods");

            ShouldGetCorrectCurrentCard(cards, currentCard);
        }

        private List<Card> GivenCardListWithoutCards()
        {
            return new List<Card>();
        }

        private static List<Card> GiveCardListWithCards()
        {
            return new List<Card>(){ new Card() };
        }

        private static List<Card> GivenDefaultCards()
        {
            return new List<Card>(){  new Card() {Name = "Undefined", Order = 1} };
        }

        private static AccountingViewModel GivenAccountingViewModel(string cardName)
        {
            return new AccountingViewModel()
            {
                Cards = new List<Card>()
                {
                    new Card() {Name = cardName, Order = 1}
                }
            };
        }

        private static AccountingViewModel GivenErrorCard()
        {
            return new AccountingViewModel()
            {
                Cards = new List<Card>()
                {
                    new Card() {Name = "Unfounded", Order = -1}
                }
            };
        }

        private void CreateDefaultCard(List<Card> emptyCard)
        {
            _cardsService.CreateDefaultCard(emptyCard);
        }

        private static void CardsShouldEqualToDefaultCard(IEnumerable<Card> defaultCards, IEnumerable<Card> cards)
        {
            cards.Should().BeEquivalentTo(defaultCards);
        }

        private static void CardsShouldNotEqualToDefaultCard(List<Card> defaultCards, List<Card> cards)
        {
            defaultCards.Should().NotBeEquivalentTo(cards);
        }

        private static void ShouldGetErrorCard(IEnumerable<Card> currentCards)
        {
            currentCards.Should().BeEquivalentTo(GivenErrorCard().Cards);
        }

        private static void ShouldGetCorrectCurrentCard(AccountingViewModel cards, AccountingViewModel currentCard)
        {
            cards.Should().BeEquivalentTo(currentCard);
        }
    }
}