using System;
using System.Collections.Generic;
using AccountingCards.Models;
using AccountingCards.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccountingCards.Controllers
{
    public class AccountingController : Controller
    {
        private static readonly AccountingViewModel _accounting = new AccountingViewModel();
        private readonly CardsService _cardsService;
        private readonly ILogger<AccountingController> _logger;

        public AccountingController(CardsService cardsService, ILogger<AccountingController> logger)
        {
            _cardsService = cardsService;
            _logger = logger;
        }

        // GET
        [Route("[controller]")]
        public IActionResult Index()
        {
            _cardsService.CreateDefaultCard(_accounting.Cards);

            return View(_accounting);
        }

        [HttpGet]
        [Route("[controller]/Card/{name}")]
        public IActionResult ShowCardDetails(string name)
        {
            var currentAccounting = new AccountingViewModel()
            {
                Cards = new List<Card>() { new Card() { Name = "Unfounded", Order = -1 } }
            };
            
            if (_accounting.Cards.Exists(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase)))
            {
                var showingCard = _accounting.Cards.Find(x => string.Equals(x.Name, name, StringComparison.CurrentCultureIgnoreCase));
                currentAccounting.Cards[0] = showingCard;
            }
            
            return View(currentAccounting);
        }
    }
}