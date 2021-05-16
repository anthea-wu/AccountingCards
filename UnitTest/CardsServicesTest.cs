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
            var accounting = GivenEmptyAccounting();
            CreateDefaultAccounting(accounting);

            CardsShouldEqualToDefaultCard(GivenDefaultCards(), accounting.Cards);
        }

        [Test]
        public void When_Accounting_Cards_Not_Empty_Should_Not_Create_Default_Card()
        {
            var accounting = GiveAccountingWithCard();
            CreateDefaultAccounting(accounting);

            CardsShouldNotEqualToDefaultCard(GivenDefaultCards(), accounting.Cards);
        }
        
        [Test]
        public void When_Cards_Not_Exist_Should_Create_Error_Card()
        {
            var emptyAccounting = GivenEmptyAccounting();
            var currentAccounting = _cardsService.GetCurrentAccountingCard(emptyAccounting, "Foods");

            ShouldGetErrorCard(currentAccounting.Cards);
        }
        
        [Test]
        public void When_Cards_Exist_Should_Get_Current_Card()
        {
            var accounting = GivenAccounting("Foods");
            var currentAccounting = _cardsService.GetCurrentAccountingCard(accounting, "Foods");

            ShouldGetCorrectCurrentCard(accounting, currentAccounting);
        }

        private AccountingViewModel GivenEmptyAccounting()
        {
            return new AccountingViewModel()
            {
                Cards = new List<Card>(),
                Details = new List<Detail>()

            };
        }

        private static AccountingViewModel GiveAccountingWithCard()
        {
            return new AccountingViewModel()
            {
                Cards = new List<Card>(){ new Card() },
                Details = new List<Detail>()

            };
        }

        private static List<Card> GivenDefaultCards()
        {
            return new List<Card>(){  new Card() {Name = "Undefined", Order = 0} };
        }

        private static AccountingViewModel GivenAccounting(string cardName)
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

        private void CreateDefaultAccounting(AccountingViewModel emptyAccounting)
        {
            _cardsService.CreateDefaultCardAndDetail(emptyAccounting);
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