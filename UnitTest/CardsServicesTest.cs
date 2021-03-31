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
        private CardsController _cardsController;
        
        [SetUp]
        public void Setup()
        {
            _cardsService = Substitute.For<CardsService>();
            _cardsController = new CardsController(_cardsService);
        }

        [Test]
        public void When_Accounting_Cards_Empty_Should_Create_Default_Card()
        {
            _cardsController.Index();
            _cardsService.Received().CreateDefaultCard(new List<Card>());
        }
    }
}