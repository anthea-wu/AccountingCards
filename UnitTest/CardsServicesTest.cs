using System.Collections.Generic;
using AccountingCards.Controllers;
using AccountingCards.Interfaces;
using AccountingCards.Models;
using AccountingCards.Services;
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
            var card = GivenEmptyCardList();
            CreateDefaultCardInEmptyCardList(card);
            CardListShouldHasOneCardAfterCreateDefaultCard(card.Count);
        }

        private static void CardListShouldHasOneCardAfterCreateDefaultCard(int cardCount)
        {
            Assert.AreEqual(1, cardCount);
        }

        private void CreateDefaultCardInEmptyCardList(List<Card> emptyCard)
        {
            _cardsService.CreateDefaultCard(emptyCard);
        }

        private List<Card> GivenEmptyCardList()
        {
            return new List<Card>();
        }
    }
}