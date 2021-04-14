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
        [Route("[controller]/{name}")]
        public IActionResult ShowCardDetails(string name)
        {
            if (_accounting.Cards.Exists(x => x.Name == name))
            {
                var showingCard = _accounting.Cards.Find(x => x.Name == name);
                //var showingDetails = _accounting.Details.Find(x => x.Name == name);
                var currentAccounting = new AccountingViewModel()
                {
                    Cards = new List<Card>() { showingCard }
                };
                return View(currentAccounting);
            }
            
            return View(_accounting);
        }
    }
}