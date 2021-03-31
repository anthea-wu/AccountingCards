using System.Collections.Generic;
using AccountingCards.Controllers;
using AccountingCards.Interfaces;
using AccountingCards.Models;
using AccountingCards.Services;
using FluentAssertions;
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
            var cards = GivenEmptyCardList();
            CreateDefaultCard(cards);

            CardsShouldEqualToDefaultCard(GivenDefaultCards(), cards);
        }

        [Test]
        public void When_Accounting_Cards_Not_Empty_Should_Not_Create_Default_Card()
        {
            var cards = GiveCards();
            CreateDefaultCard(cards);

            CardsShouldNotEqualToDefaultCard(GivenDefaultCards(), cards);
        }

        private List<Card> GivenEmptyCardList()
        {
            return new List<Card>();
        }

        private static List<Card> GiveCards()
        {
            return new List<Card>(){ new Card() };
        }

        private static List<Card> GivenDefaultCards()
        {
            return new List<Card>(){  new Card() {Name = "Undefined", Order = 1} };
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
    }
}